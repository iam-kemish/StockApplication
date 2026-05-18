using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Models.RefreshTokens;
using StockApplicationApi.Repositary.RefreshTokenRepositary;
using StockApplicationApi.Services.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockApplicationApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;
        private readonly IRefreshToken _IRefresh;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public AuthService(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService,
            ILogger<AuthService> logger,
                
        IRefreshToken refreshToken,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
            _IRefresh = refreshToken;
            _issuer = configuration["JWT:Issuer"] ?? throw new Exception("JWT Issuer is missing!");
            _audience = configuration["JWT:Audience"] ?? throw new Exception("JWT Audience is missing!");
            var secretKey = configuration["JWT:SigningKey"] ?? throw new Exception("JWT Secret is missing!");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }

        public async Task<AuthResponseDTO> Register(RegisterDTO dto)
        {

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new ConflictException("Email already exists.");
            }

            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };

            _logger.LogInformation("Registering new user: {UserName}", user.UserName);

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                _logger.LogError("User registration failed for {UserName}. Errors: {Errors}", user.UserName, string.Join(", ", errors));
                throw new OperationFailedException("Operation failed", errors);
            }

            // create Customer role if doesnt exist
            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                _logger.LogInformation("Creating 'Customer' role as it does not exist.");
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            // assign default role
            await _userManager.AddToRoleAsync(user, "Customer");

            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = null
            };
        }

        public async Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            _logger.LogInformation("Attempting login for email: {Email}", dto.Email);
            // find user by email
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                _logger.LogWarning("Login failed for email: {Email}. User not found.", dto.Email);
                throw new NotFoundException("Invalid credentials this username might be wrong or empty");
            }   

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isPasswordValid)
            {
                _logger.LogWarning("Login failed for email: {Email}. Invalid password.", dto.Email);
                throw new UnAuthorizedException("Invalid credentials check if Password is wrong or empty.");
            }
            var token = await _tokenService.CreateAccessToken(user);
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = _tokenService.GenerateRefreshToken(),
                Expires = DateTime.UtcNow.AddDays(7), 
                Created = DateTime.UtcNow,
                AppUserId = user.Id,
                IsUsed = false,
                IsRevoked = false
            };
            await _IRefresh.SaveRefreshTokens(refreshToken);
            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token =  token,
                RefreshToken = refreshToken.Token
            };
        }
       
        public async Task<AuthResponseDTO> RefreshToken(string expiredAccessToken, string refreshToken)
        {
           
            var principal = GetPrincipalFromExpiredToken(expiredAccessToken);
            var userId = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizedException("Invalid token");

           
            var storedToken = await _IRefresh.GetRefreshToken(refreshToken);

            if (storedToken == null)
                throw new NotFoundException("Refresh Token not found.");
            if(storedToken.IsUsed || storedToken.IsRevoked)
            {
                    await _IRefresh.RevokeAllTokens(storedToken.AppUserId);
                 _logger.LogWarning("Refresh token {RefreshToken} for user {UserId} is invalid. It has been revoked or already used.", refreshToken, userId);
                throw new UnAuthorizedException("Refresh token is invalid. It has been revoked.");
            }
               

            if (storedToken.AppUserId != userId) 
                throw new UnAuthorizedException("Token user mismatch");

        
            if (storedToken.IsUsed)
                throw new UnAuthorizedException("Refresh token has already been used.");

            if (storedToken.IsRevoked)
                throw new UnAuthorizedException("Refresh token has been revoked.");

            if (storedToken.Expires < DateTime.UtcNow)
                throw new UnAuthorizedException("Refresh token has expired.");

            // Mark as used (rotation)
            storedToken.IsUsed = true;
            await _IRefresh.UpdateRefreshToken(storedToken);

            // Create new tokens
            var user = await _userManager.FindByIdAsync(storedToken.AppUserId);
            if(user == null)
                throw new NotFoundException("User not found.");
            var newAccessToken = await _tokenService.CreateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            // Save new refresh token
            var newToken = new RefreshToken
            {
                Token = newRefreshToken,
                Expires = DateTime.UtcNow.AddDays(7),
                AppUserId = user.Id,
                IsRevoked = false,
                IsUsed = false,
            };
            await _IRefresh.SaveRefreshTokens(newToken);

            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }

        // You need to add this helper method
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateLifetime = false,  
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                // Verify it's a JWT token with correct algorithm
                if (validatedToken is not JwtSecurityToken jwtToken ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new UnAuthorizedException("Invalid token");
                }

                return principal;
            }
            catch (Exception ex)
            {
                throw new UnAuthorizedException($"Token validation failed: {ex.Message}");
            }
        }

    }
}

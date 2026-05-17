using Microsoft.AspNetCore.Identity;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Models.RefreshTokens;
using StockApplicationApi.Repositary.RefreshTokenRepositary;
using StockApplicationApi.Services.Token;

namespace StockApplicationApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;
        private readonly IRefreshToken _IRefresh;

        public AuthService(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService,
            ILogger<AuthService> logger,
            IRefreshToken refreshToken
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
            _IRefresh = refreshToken;
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
                AppUserId = user.Id
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
        public async Task<AuthResponseDTO> RefreshToken(string token, string refreshToken)
        {
            var storedToken = await _IRefresh.GetRefreshToken(refreshToken);
            if (storedToken == null)
            {
                throw new NotFoundException("Refresh Token not found.");
            }
            if (storedToken.IsUsed)
                throw new UnAuthorizedException("Refresh token has already been used.");

            if (storedToken.IsRevoked)
                throw new UnAuthorizedException("Refresh token has been revoked.");

            if (storedToken.Expires < DateTime.UtcNow)
                throw new UnAuthorizedException("Refresh token has expired. Please login again.");
            storedToken.IsUsed = true;
            await _IRefresh.UpdateRefreshToken(storedToken);

            var user = storedToken.AppUser;
            var newAccessToken = await _tokenService.CreateAccessToken(user);
            var newRefreshToken = new RefreshToken
            {
                Token = _tokenService.GenerateRefreshToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                AppUserId = user.Id,
                IsRevoked = false,
                IsUsed = false,
            };
            await _IRefresh.SaveRefreshTokens(newRefreshToken);

            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                
            };
        }

    }
}

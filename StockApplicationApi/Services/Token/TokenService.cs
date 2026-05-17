using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StockApplicationApi.Database;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Models.RefreshTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StockApplicationApi.Services.Token
{
    public class TokenService : ITokenService
    {
      
        private readonly UserManager<AppUser> _UserManager;
        private readonly string _issuer;
        private readonly string _audience;
      
        private readonly SymmetricSecurityKey _key;
        private readonly AppDbContext _dbContext;

        public TokenService(IConfiguration configuration, UserManager<AppUser> userManager, AppDbContext dbContext)
        {
          
            _UserManager = userManager;
            _dbContext = dbContext;
             var secretKey = configuration["JWT:SigningKey"] ?? throw new Exception("JWT Secret is missing!");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            _issuer = configuration["JWT:Issuer"] ?? throw new Exception("JWT Issuer is missing!");
            _audience = configuration["JWT:Audience"] ?? throw new Exception("JWT Audience is missing!");
        }
        public async Task<string> CreateAccessToken(AppUser user)
        {
            var roles = await _UserManager.GetRolesAsync(user);
          
          
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
            };  
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var TokenDesc = new SecurityTokenDescriptor
            {
               Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDesc);
            return tokenHandler.WriteToken(token);
        }   
        public string GenerateRefreshToken()
        {
          return  Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        }

        public Task<AuthResponseDTO> RefreshToken(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task SaveRefreshTokens(RefreshToken refreshToken)
        {
           await _dbContext.RefreshTokens.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();
        }
    }
}

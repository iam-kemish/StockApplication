using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Models.RefreshTokens;

namespace StockApplicationApi.Services.Token
{
    public interface ITokenService
    {
      Task<string> CreateAccessToken(AppUser user);
        string GenerateRefreshToken();
        Task SaveRefreshTokens(RefreshToken refreshToken);

        Task <AuthResponseDTO> RefreshToken(string token, string refreshToken);
    }
}

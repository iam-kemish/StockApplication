using StockApplicationApi.Models;

namespace StockApplicationApi.Services.Token
{
    public interface ITokenService
    {
      Task<string> CreateAccessToken(AppUser user);
        string GenerateRefreshToken();
     
    }
}

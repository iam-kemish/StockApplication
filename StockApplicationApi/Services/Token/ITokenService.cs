using StockApplicationApi.Models;

namespace StockApplicationApi.Services.Token
{
    public interface ITokenService
    {
        string CreateAccessToken(AppUser user);
    }
}

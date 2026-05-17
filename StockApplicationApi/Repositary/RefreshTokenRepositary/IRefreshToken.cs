using StockApplicationApi.Models.RefreshTokens;

namespace StockApplicationApi.Repositary.RefreshTokenRepositary
{
    public interface IRefreshToken
    {
     
        Task SaveRefreshTokens(RefreshToken refreshToken);
        Task<RefreshToken?> GetRefreshToken(string token);
        Task  UpdateRefreshToken(RefreshToken refreshToken);
        
    }
}

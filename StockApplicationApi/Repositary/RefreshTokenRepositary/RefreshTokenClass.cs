using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Database;
using StockApplicationApi.Models.RefreshTokens;

namespace StockApplicationApi.Repositary.RefreshTokenRepositary
{
    public class RefreshTokenClass : IRefreshToken
    {
        private readonly AppDbContext _Db;

        public RefreshTokenClass(AppDbContext Db)
        {
            _Db = Db;
        }
     
        public async Task<RefreshToken?> GetRefreshToken(string token)
        {
         return await _Db.RefreshTokens.Include(u=>u.AppUser).FirstOrDefaultAsync(u => u.Token == token);
        }

        public async Task SaveRefreshTokens(RefreshToken refreshToken)
        {
            await _Db.RefreshTokens.AddAsync(refreshToken);
            await _Db.SaveChangesAsync();
        }

        public async Task UpdateRefreshToken(RefreshToken refreshToken)
        {
            _Db.RefreshTokens.Update(refreshToken);
            await _Db.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Models.RefreshTokens;
using StockApplicationApi.Database;

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

        public async Task<int> MarkUsedIfUnused(string token, DateTime usedAt)
        {
           return  await _Db.RefreshTokens.Where(r => r.Token == token && !r.IsUsed)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(r => r.IsUsed, true)
                .SetProperty(r => r.UsedAt, usedAt));

        }        
        public async Task RevokeAllTokens(string userId)
        {
           await _Db.RefreshTokens.Where(r => r.AppUserId == userId)
       .ExecuteUpdateAsync(s => s.SetProperty(r => r.IsRevoked, true));
        }

        public async Task SaveRefreshTokens(RefreshToken refreshToken)
        {
            await _Db.RefreshTokens.AddAsync(refreshToken);
            await _Db.SaveChangesAsync();
        }

        public async Task UpdateRefreshToken(RefreshToken refreshToken)
        {
            await _Db.RefreshTokens
       .Where(r => r.Id == refreshToken.Id)
       .ExecuteUpdateAsync(s => s.SetProperty(r => r.IsUsed, true));
        }
    }
}

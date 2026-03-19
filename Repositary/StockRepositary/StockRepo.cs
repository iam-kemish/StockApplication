using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StockApplication.Database;
using StockApplication.Models;

namespace StockApplication.Repositary.StockRepositary
{
    public class StockRepo : IStock
    {
        private readonly AppDbContext _Db;

        public StockRepo(AppDbContext appDbContext)
        {
            _Db = appDbContext;
        }
        public async Task AddStock(Stock Stock)
        {
            _Db.Stocks.Add(Stock);
          await  _Db.SaveChangesAsync();
        }

        public async Task DeleteStock(Stock Stock)
        {
            _Db.Stocks.Remove(Stock);
           await _Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllStocks(Expression<Func<Stock, bool>>? filter = null)
        {
            var query = _Db.Stocks.Include(p => p.Comments).AsNoTracking().AsQueryable();
            if (filter != null) 
            {
                query = query.Where(filter);
            }
           return await query.ToListAsync();
        }

     

        public Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null)
        {
            var query = _Db.Stocks.Include(p => p.Comments).AsNoTracking().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefaultAsync();
        }

        public async Task UpdateStock(Stock Stock)
        {
            _Db.Stocks.Update(Stock);
           await _Db.SaveChangesAsync();
        }
    }
}

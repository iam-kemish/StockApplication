using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Database;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;

namespace StockApplicationApi.Repositary.StockRepositary
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

        public async Task<IEnumerable<Stock>> GetAllStocks(StockQuery stockQuery)
        {
            var query = _Db.Stocks.Include(p => p.Comments).AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(stockQuery.CompanyName))
            {
                query = query.Where(u => u.CompanyName.ToLower().Contains(stockQuery.CompanyName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(stockQuery.Symbol))
            {
                query = query.Where(u => u.Symbol.ToLower().Contains(stockQuery.Symbol.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(stockQuery.SortBy))
            {
                if(stockQuery.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    query = stockQuery.IsDescending ? query.OrderByDescending(u=>u.Symbol) : query.OrderBy(u=>u.Symbol);
                }
                if(stockQuery.SortBy.Equals("Marketcap", StringComparison.OrdinalIgnoreCase))
                {
                    query = stockQuery.IsDescending ? query.OrderByDescending(u => u.MarketCap) : query.OrderBy(u => u.MarketCap);
                }
            }
            var skipNumber = (stockQuery.PageNumber - 1) * stockQuery.PageSize;

            return await query.Skip(skipNumber).Take(stockQuery.PageSize).ToListAsync();
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

        public Task<bool> StockExists(int? id)
        {
            return _Db.Stocks.AnyAsync(u => u.Id == id);
        }

        public async Task UpdateStock(Stock Stock)
        {
            _Db.Stocks.Update(Stock);
           await _Db.SaveChangesAsync();
        }
    }
}

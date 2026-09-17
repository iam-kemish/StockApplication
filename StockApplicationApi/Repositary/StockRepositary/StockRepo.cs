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
        public async Task AddStock(Stock Stock, CancellationToken cancellationToken= default)
        {
            _Db.Stocks.Add(Stock);
          await  _Db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStock(Stock Stock, CancellationToken cancellationToken= default)
        {
            _Db.Stocks.Update(Stock);
            await _Db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStock(Stock Stock, CancellationToken cancellationToken= default)
        {
            _Db.Stocks.Remove(Stock);
           await _Db.SaveChangesAsync(cancellationToken);
        }

        public async Task<(IEnumerable<Stock> Stocks, int TotalCount)> GetAllStocks(StockQuery stockQuery, CancellationToken cancellationToken= default)
        {
            var query = _Db.Stocks.Include(p => p.Comments).AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(stockQuery.companyName))
            {
                query = query.Where(u => EF.Functions.ILike(u.CompanyName, $"%{stockQuery.companyName}%"));
            }
            if (!string.IsNullOrWhiteSpace(stockQuery.symbol))
            {
                query = query.Where(u => EF.Functions.ILike(u.Symbol, $"%{stockQuery.symbol}%"));
            }
             var totalCount = await query.CountAsync(cancellationToken);
            if (!string.IsNullOrWhiteSpace(stockQuery.sortBy))
            {
                if(stockQuery.sortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    query = stockQuery.isDescending ? query.OrderByDescending(u=>u.Symbol) : query.OrderBy(u=>u.Symbol);
                }
                if(stockQuery.sortBy.Equals("Marketcap", StringComparison.OrdinalIgnoreCase))
                {
                    query = stockQuery.isDescending ? query.OrderByDescending(u => u.MarketCap) : query.OrderBy(u => u.MarketCap);
                }
            }

            var skipNumber = (stockQuery.pageNumber - 1) * stockQuery.pageSize;

            var stocks = await query.Skip(skipNumber).Take(stockQuery.pageSize).ToListAsync(cancellationToken);
            return (stocks, totalCount);
        }

        public Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null, CancellationToken cancellationToken = default, bool tracking = false)
        {
            var query = _Db.Stocks.Include(p => p.Comments).AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefaultAsync(cancellationToken);
        }

    

        public Task<bool> StockExists(int id, CancellationToken cancellationToken= default)
        {
            return _Db.Stocks.AnyAsync(u => u.Id == id, cancellationToken);
        }

        
    }
}

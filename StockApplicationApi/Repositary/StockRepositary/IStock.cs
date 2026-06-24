using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using System.Linq.Expressions;

namespace StockApplicationApi.Repositary.StockRepositary
{
    public interface IStock
    {
        Task AddStock(Stock stock, CancellationToken cancellationToken = default);
        Task UpdateStock(Stock stock, CancellationToken cancellationToken = default);
        Task DeleteStock(Stock stock, CancellationToken cancellationToken = default);
        Task<IEnumerable<Stock>> GetAllStocks(StockQuery stockQuery, CancellationToken cancellationToken = default);
        Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null, CancellationToken cancellationToken = default, bool tracking = false);
        Task<bool> StockExists(int id, CancellationToken cancellationToken = default);
    }
}

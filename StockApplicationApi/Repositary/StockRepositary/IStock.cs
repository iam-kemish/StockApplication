using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using System.Linq.Expressions;

namespace StockApplicationApi.Repositary.StockRepositary
{
    public interface IStock
    {
        Task<IEnumerable<Stock>> GetAllStocks(StockQuery stockQuery);

        Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null,  bool tracking = false);
        Task AddStock(Stock Stock);
       Task UpdateStock(Stock Stock);
        Task DeleteStock(Stock Stock);
        Task<bool> StockExists(int id);
    }
}

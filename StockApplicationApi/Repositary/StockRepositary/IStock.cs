using Microsoft.Extensions.Hosting;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using System.Linq.Expressions;

namespace StockApplicationApi.Repositary.StockRepositary
{
    public interface IStock
    {
        Task<IEnumerable<Stock>> GetAllStocks(StockQuery stockQuery);
  
        Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null);
        Task AddStock(Stock Stock);
        Task<Stock?> GetStockForUpdate(int id);
        Task UpdateStock(); 
        Task DeleteStock(Stock Stock);
        Task<bool> StockExists(int id);
    }
}

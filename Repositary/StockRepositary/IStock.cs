using Microsoft.Extensions.Hosting;
using StockApplication.Models;
using System.Linq.Expressions;

namespace StockApplication.Repositary.StockRepositary
{
    public interface IStock
    {
        Task<IEnumerable<Stock>> GetAllStocks(Expression<Func<Stock, bool>>? filter = null);
  
        Task<Stock?> GetStock(Expression<Func<Stock, bool>>? filter = null);
        Task AddStock(Stock Stock);
        Task UpdateStock(Stock Stock);
        Task DeleteStock(Stock Stock);
    }
}

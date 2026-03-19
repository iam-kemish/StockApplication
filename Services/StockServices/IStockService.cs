using StockApplication.Models;
using StockApplication.Models.DTOs;

namespace StockApplication.Services.StockServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllStocks();        
        Task<StockDTO?> GetStockById(int id);
        Task<StockDTO> AddStock(StockCreateDTO stock);
        Task <StockDTO>UpdateStock(StockUpdateDTO stock);          
        Task DeleteStock(int id);
    }
}

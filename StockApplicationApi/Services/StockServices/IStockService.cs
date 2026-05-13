using StockApplicationApi.Helpers;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.StockServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery);        
        Task<StockDTO> GetStockById(int id, string userId);
        Task<StockDTO> AddStock(StockCreateDTO stock, string userId);
        Task <StockDTO>UpdateStock(int id, StockUpdateDTO stock, string userId);          
        Task DeleteStock(int id, string userId);
    }
}

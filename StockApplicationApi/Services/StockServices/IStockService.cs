using StockApplicationApi.Helpers;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.StockServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery);        
        Task<StockDTO> GetStockById(int id);
        Task<StockDTO> AddStock(StockCreateDTO stock);
        Task <StockDTO>UpdateStock(int id, StockUpdateDTO stock);          
        Task DeleteStock(int id);
    }
}

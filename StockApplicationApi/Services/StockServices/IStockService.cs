using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.StockServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllStocks();        
        Task<StockDTO> GetStockById(int id);
        Task<StockDTO> AddStock(StockCreateDTO stock);
        Task <StockDTO>UpdateStock(StockUpdateDTO stock);          
        Task DeleteStock(int id);
    }
}

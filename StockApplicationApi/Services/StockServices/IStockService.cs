using StockApplicationApi.Helpers;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.StockServices
{
    public interface IStockService
    {
        //Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery);        
       
        Task<StockDTO> AddStock(StockCreateDTO stock, bool isAdmin = true);
        Task <StockDTO>UpdateStock(int id, StockUpdateDTO stock, bool isAdmin = true);          
        Task DeleteStock(int id, bool isAdmin = true);
    }
}

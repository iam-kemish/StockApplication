using AutoMapper;
using StockApplication.Exceptions;
using StockApplication.Models;
using StockApplication.Models.DTOs;
using StockApplication.Repositary.StockRepositary;

namespace StockApplication.Services.StockServices
{
    public class StockClass : IStockService
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
       

        public StockClass(IStock stock, IMapper mapper)
        {
            _IStock = stock;
            _IMapper = mapper;
          
        }
        public async Task<StockDTO> AddStock(StockCreateDTO stock)
        {
            if (await _IStock.GetStock(u => u.CompanyName.ToLower() == stock.CompanyName.ToLower()) != null)
            {
                throw new ConflictException("This company name already exists.");
                // ↑ good — already correct
            }

            var createdStock = _IMapper.Map<Stock>(stock);
            await _IStock.AddStock(createdStock);

            return _IMapper.Map<StockDTO>(createdStock);
        }

        public async Task DeleteStock(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                throw new NotFoundException("Stock", id);
                // Better than plain Exception
            }
            await _IStock.DeleteStock(stock);
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocks()
        {
            var stocks = await _IStock.GetAllStocks();
            // Usually you don't throw when list is empty — just return empty list
            // So better to remove this check completely
            return _IMapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO?> GetStockById(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                throw new NotFoundException("Stock", id);
            }
            return _IMapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO> UpdateStock(StockUpdateDTO stock)
        {
            var existingStock = await _IStock.GetStock(u => u.Id == stock.Id);
            if (existingStock == null)
            {
                throw new NotFoundException("Stock", stock.Id);
            }

            // You can also do partial update with AutoMapper if you want:
            // _IMapper.Map(stock, existingStock);

            existingStock.MarketCap = stock.MarketCap;
            existingStock.Purchase = stock.Purchase;
            existingStock.LastDiv = stock.LastDiv;
            existingStock.Industry = stock.Industry;
            existingStock.CompanyName = stock.CompanyName;

            await _IStock.UpdateStock(existingStock);

            return _IMapper.Map<StockDTO>(existingStock);
        }



    }
    }

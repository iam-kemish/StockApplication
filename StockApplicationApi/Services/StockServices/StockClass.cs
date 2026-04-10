using AutoMapper;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;

namespace StockApplicationApi.Services.StockServices
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
                throw new ConflictException("This Company name already exists.");

            }
            if (await _IStock.GetStock(u => u.Industry.ToLower() == stock.Industry.ToLower()) != null)
            {
                throw new ConflictException("This Industry name already exists.");
               
            }
            if (await _IStock.GetStock(u => u.Symbol.ToLower() == stock.Symbol.ToLower()) != null)
            {
                throw new ConflictException("This Symbol name already exists.");

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

        public async Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery)
        {
            var stocks = await _IStock.GetAllStocks(stockQuery);
            
            return _IMapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO> GetStockById(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                throw new NotFoundException("Stock", id);
            }
            return _IMapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO> UpdateStock(int id, StockUpdateDTO stock)
        {
            var existingStock = await _IStock.GetStock(u => u.Id == id);
            if (existingStock == null)
            {
                throw new NotFoundException("Stock", id);
            }

           
            existingStock.MarketCap = stock.MarketCap;
            existingStock.Purchase = stock.Purchase;
            existingStock.LastDiv = stock.LastDiv;
            existingStock.Industry = stock.Industry;
            existingStock.CompanyName = stock.CompanyName;
            existingStock.Symbol = stock.Symbol;

            await _IStock.UpdateStock(existingStock);

            return _IMapper.Map<StockDTO>(existingStock);
        }



    }
    }

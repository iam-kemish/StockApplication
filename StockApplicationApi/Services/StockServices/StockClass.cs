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
        private readonly ILogger<StockClass> _logger;

        public StockClass(IStock stock, IMapper mapper, ILogger<StockClass> logger)
        {
            _IStock = stock;
            _IMapper = mapper;
            _logger = logger;
        }
        public async Task<StockDTO> AddStock(StockCreateDTO stock)
        {
            if (await _IStock.GetStock(u => u.CompanyName.ToLower() == stock.CompanyName.ToLower()) != null)
            {
                _logger.LogWarning("Attempt to create a stock with an existing company name: {CompanyName}", stock.CompanyName);
                throw new ConflictException("This Company name already exists.");

            }
            if (await _IStock.GetStock(u => u.Industry.ToLower() == stock.Industry.ToLower()) != null)
            {
                _logger.LogWarning("Attempt to create a stock with an existing industry name: {Industry}", stock.Industry);
                throw new ConflictException("This Industry name already exists.");
               
            }
            if (await _IStock.GetStock(u => u.Symbol.ToLower() == stock.Symbol.ToLower()) != null)
            {
                _logger.LogWarning("Attempt to create a stock with an existing symbol name: {Symbol}", stock.Symbol);
                throw new ConflictException("This Symbol name already exists.");

            }

            var createdStock = _IMapper.Map<Stock>(stock);
            await _IStock.AddStock(createdStock);
            _logger.LogInformation("Stock created successfully: {CompanyName}", stock.CompanyName);
            return _IMapper.Map<StockDTO>(createdStock);
        }

        public async Task DeleteStock(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to delete a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
                // Better than plain Exception
            }
            await _IStock.DeleteStock(stock);
            _logger.LogInformation("Stock with ID: {StockId} deleted successfully", id);
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery)
        {
            var stocks = await _IStock.GetAllStocks(stockQuery);
            _logger.LogInformation("Retrieved all stocks");
            return _IMapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO> GetStockById(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to retrieve a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
            }

            return _IMapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO> UpdateStock(int id, StockUpdateDTO stock)
        {
            var existingStock = await _IStock.GetStock(u => u.Id == id);
            if (existingStock == null)
            {
                _logger.LogWarning("Attempt to update a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
            }

           
            existingStock.MarketCap = stock.MarketCap;
            existingStock.Purchase = stock.Purchase;
            existingStock.LastDiv = stock.LastDiv;
            existingStock.Industry = stock.Industry;
            existingStock.CompanyName = stock.CompanyName;
            existingStock.Symbol = stock.Symbol;

            await _IStock.UpdateStock(existingStock);
            _logger.LogInformation("Stock with ID: {StockId} updated successfully", id);

            return _IMapper.Map<StockDTO>(existingStock);
        }

    }
    }

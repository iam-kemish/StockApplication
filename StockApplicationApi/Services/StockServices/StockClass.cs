using AutoMapper;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;

namespace StockApplicationApi.Services.StockServices
{

    public class StockClass : IStockService
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly ILogger<StockClass> _logger;
        private readonly IRedisService _cache;
        string cacheKey = "stock";
        public StockClass(IStock stock, IMapper mapper, ILogger<StockClass> logger, IRedisService redisService)
        {
            _IStock = stock;
            _IMapper = mapper;
            _logger = logger;
            _cache = redisService;
        }
        public async Task<StockDTO> AddStock(StockCreateDTO stock)
        {
           
            var existing = await _IStock.GetStock(u =>
                u.CompanyName.ToLower() == stock.CompanyName.ToLower() ||
                u.Symbol.ToLower() == stock.Symbol.ToLower() ||
                u.Industry.ToLower() == stock.Industry.ToLower());

            if (existing != null)
            {
               
                string conflictDetail = "";

                if (existing.CompanyName.Equals(stock.CompanyName, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Company Name '{stock.CompanyName}'";
                else if (existing.Symbol.Equals(stock.Symbol, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Symbol '{stock.Symbol}'";
                else if (existing.Industry.Equals(stock.Industry, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Industry '{stock.Industry}'";

               
                _logger.LogWarning("Conflict detected: {ConflictDetail}", conflictDetail);

             
                throw new ConflictException($"{conflictDetail} already exists in our records.");
            }
            var createdStock = _IMapper.Map<Stock>(stock);
            await _IStock.AddStock(createdStock);
            await _cache.RemoveDataAsync(cacheKey); 
            _logger.LogInformation("Stock created and removed cache successfully: {CompanyName}", stock.CompanyName);
            return _IMapper.Map<StockDTO>(createdStock);
        }

        public async Task DeleteStock(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to delete a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
               
            }
            await _IStock.DeleteStock(stock);
           
            await _cache.RemoveDataAsync(cacheKey); 
            _logger.LogInformation("Cache removed successfully after deleting stock with ID: {StockId}", id);
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery)
        {
            var cachedStocks = await _cache.GetDatasAsync<IEnumerable<StockDTO>>(cacheKey);
            if (cachedStocks != null)
            {
                _logger.LogInformation("Retrieved all stocks from cache");
                return cachedStocks;
            }

            var stocks = await _IStock.GetAllStocks(stockQuery);
            _logger.LogInformation("Retrieved all stocks");
            await _cache.SetDataAsync(cacheKey, _IMapper.Map<IEnumerable<StockDTO>>(stocks), DateTime.UtcNow.AddMinutes(5));
            return _IMapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO> GetStockById(int id)
        {
          
            var cachedStock = await _cache.GetDatasAsync<StockDTO>($"{cacheKey}_{id}");
            if (cachedStock != null)
            {
                _logger.LogInformation("Stock with ID: {StockId} retrieved from cache", id);
                return cachedStock;
            }
            //If no cache, get from database
            _logger.LogInformation("Stock with ID: {StockId} not found in cache, retrieving from database", id);
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to retrieve a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
            }
            await _cache.SetDataAsync($"{cacheKey}_{id}", _IMapper.Map<StockDTO>(stock), DateTime.UtcNow.AddMinutes(5));
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
            await _cache.RemoveDataAsync($"{cacheKey}_{id}");
            await _cache.RemoveDataAsync(cacheKey);
            _logger.LogInformation("Stock with ID: {StockId} updated successfully", id);

            return _IMapper.Map<StockDTO>(existingStock);
        }

    }
    }

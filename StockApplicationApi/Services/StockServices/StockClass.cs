using AutoMapper;
using StockApplicationApi.Exceptions;

using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Services.StockServices
{

    public class StockClass : IStockService
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly ILogger<StockClass> _logger;
        private readonly IRedisService _cache;

        public StockClass(IStock stock, IMapper mapper, ILogger<StockClass> logger, IRedisService redisService)
        {
            _IStock = stock;
            _IMapper = mapper;
            _logger = logger;
            _cache = redisService;
        }
        public async Task<StockDTO> AddStock(StockCreateDTO stock,  bool isAdmin = true)
        {
           if(!isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to add stock");
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }
            var existing = await _IStock.GetStock(u =>
                u.CompanyName.ToLower() == stock.CompanyName.ToLower() ||
                u.Symbol.ToLower() == stock.Symbol.ToLower());

            if (existing != null)
            {
               
                string conflictDetail = "";

                if (existing.CompanyName.Equals(stock.CompanyName, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Company Name '{stock.CompanyName}'";
                else if (existing.Symbol.Equals(stock.Symbol, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Symbol '{stock.Symbol}'";
                
                _logger.LogWarning("Conflict detected: {ConflictDetail}", conflictDetail);

             
                throw new ConflictException($"{conflictDetail} already exists in our records.");
            }
            var createdStock = _IMapper.Map<Stock>(stock);
            await _IStock.AddStock(createdStock);
            await _cache.RemoveByPrefixAsync(CacheKeys.StockList); 
            _logger.LogInformation("Stock created and removed cache successfully: {CompanyName}", stock.CompanyName   );
            return _IMapper.Map<StockDTO>(createdStock);
        }

        public async Task DeleteStock(int id,  bool isAdmin = true)
        {
            if (!isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to delete stock with ID: {StockId}", id);
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }
            var stock = await _IStock.GetStock(u => u.Id == id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to delete a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
               
            }
            await _IStock.DeleteStock(stock);
           
            await _cache.RemoveByPrefixAsync(CacheKeys.StockList); 
            await _cache.RemoveDataAsync(CacheKeys.StockDetail(id));
            _logger.LogInformation("Cache removed successfully after deleting stock with ID: {StockId}", id);
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocks(StockQuery stockQuery)
        {
            string GetCachekey = CacheKeys.GetStockListKey(stockQuery);
            var cachedStocks = await _cache.GetDatasAsync<IEnumerable<StockDTO>>(GetCachekey);
            if (cachedStocks != null)
            {
                _logger.LogInformation("Retrieved all stocks from cache");
                return cachedStocks;
            }

            var stocks = await _IStock.GetAllStocks(stockQuery);
            _logger.LogInformation("Retrieved all stocks");
            var resultedStocks = _IMapper.Map<IEnumerable<StockDTO>>(stocks);
            await _cache.SetDataAsync(GetCachekey, resultedStocks, TimeSpan.FromMinutes(5));
            return resultedStocks;
        }

        public async Task<StockDTO> GetStockById(int id)
        {
          
            var cachedStock = await _cache.GetDatasAsync<StockDTO>(CacheKeys.StockDetail(id));
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
            await _cache.SetDataAsync(CacheKeys.StockDetail(id), _IMapper.Map<StockDTO>(stock), TimeSpan.FromMinutes(5));
            return _IMapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO> UpdateStock(int id, StockUpdateDTO stock,  bool isAdmin = true)
        {           
            if (!isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to update stock with ID: {StockId}", id);
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }

            var existingStock = await _IStock.GetStock(u => u.Id == id, tracking: true);
            if (existingStock == null)
            {
                _logger.LogWarning("Attempt to update a non-existent stock with ID: {StockId}", id);
                throw new NotFoundException("Does this Stock exists?");
            }
            _IMapper.Map(stock, existingStock);
          
            await _IStock.UpdateStock(existingStock);
            await _cache.RemoveDataAsync(CacheKeys.StockDetail(id));
            await _cache.RemoveByPrefixAsync(CacheKeys.StockList); 
            _logger.LogInformation("Stock with ID: {StockId} updated successfully", id);

            return _IMapper.Map<StockDTO>(existingStock);
        }

    }
    }

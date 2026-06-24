using AutoMapper;
using MediatR;
using StockApplicationApi.Features.Stocks.Queries;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class GetAllStocksHandler: IRequestHandler<GetAllStocksQuery, IEnumerable<StockDTO>>
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly IRedisService _cache;
        private readonly ILogger<GetAllStocksHandler> _logger;

        public GetAllStocksHandler(IStock IStock, IMapper IMapper, IRedisService cache, ILogger<GetAllStocksHandler> logger)
        {
            _IStock = IStock;
            _IMapper = IMapper;
            _cache = cache;
            _logger = logger;
        }
        public async Task<IEnumerable<StockDTO>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            string GetCachekey = CacheKeys.GetStockListKey(request.StockQuery);
            var cachedStocks = await _cache.GetDatasAsync<IEnumerable<StockDTO>>(GetCachekey);
            if (cachedStocks != null)
            {
                _logger.LogInformation("Retrieved all stocks from cache");
                return cachedStocks;
            }

            var stocks = await _IStock.GetAllStocks(request.StockQuery, cancellationToken);
            _logger.LogInformation("Retrieved all stocks");
            var resultedStocks = _IMapper.Map<IEnumerable<StockDTO>>(stocks);
            await _cache.SetDataAsync(GetCachekey, resultedStocks, TimeSpan.FromMinutes(5));
            return resultedStocks;
        }
    }
}

using AutoMapper;
using MediatR;
using StockApplicationApi.Features.Stocks.Queries;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class GetAllStocksHandler: IRequestHandler<GetAllStocksQuery,PaginatedResult<StockDTO>>
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
        public async Task<PaginatedResult<StockDTO>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Step 1: building cache key");
            string GetCachekey = CacheKeys.GetStockListKey(request.StockQuery);

            _logger.LogInformation("Step 2: checking cache");
            var cachedStocks = await _cache.GetDatasAsync<PaginatedResult<StockDTO>>(GetCachekey);
            if (cachedStocks != null)
            {
                _logger.LogInformation("Retrieved all stocks from cache");
                return cachedStocks;
            }

            _logger.LogInformation("Step 3: querying repo");
            var (stocks, totalCount) = await _IStock.GetAllStocks(request.StockQuery, cancellationToken);

            _logger.LogInformation("Step 4: mapping");
            var resultedStocks = _IMapper.Map<IEnumerable<StockDTO>>(stocks);

            _logger.LogInformation("Step 5: building result");
            var result = new PaginatedResult<StockDTO>
            {
                Items = resultedStocks.ToList(),
                TotalCount = totalCount,
                PageNumber = request.StockQuery.PageNumber,
                PageSize = request.StockQuery.PageSize
            };

            _logger.LogInformation("Step 6: caching");
            await _cache.SetDataAsync(GetCachekey, result, TimeSpan.FromMinutes(5));

            _logger.LogInformation("Step 7: returning");
            return result;
        }



    }
}

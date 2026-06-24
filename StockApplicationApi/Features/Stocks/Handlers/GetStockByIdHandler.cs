using AutoMapper;
using MediatR;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Queries;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class GetStockByIdHandler: IRequestHandler<GetStockById, StockDTO>
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly ILogger<GetStockByIdHandler> _logger;
        private readonly IRedisService _cache;

        public GetStockByIdHandler(IStock stock, IMapper mapper, ILogger<GetStockByIdHandler> logger, IRedisService cache)
        {
            _IStock = stock;
            _IMapper = mapper;
            _logger = logger;
            _cache = cache;
        }
        public async Task<StockDTO> Handle(GetStockById request, CancellationToken cancellationToken)
        {
            var cachedStock = await _cache.GetDatasAsync<StockDTO>(CacheKeys.StockDetail(request.id));
            if (cachedStock != null)
            {
                _logger.LogInformation("Stock with ID: {StockId} retrieved from cache", request.id);
                return cachedStock;
            }
            //If no cache, get from database
            _logger.LogInformation("Stock with ID: {StockId} not found in cache, retrieving from database", request.id);
            var stock = await _IStock.GetStock(u => u.Id == request.id, cancellationToken);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to retrieve a non-existent stock with ID: {StockId}", request.id);
                throw new NotFoundException("Does this Stock exists?");
            }
            await _cache.SetDataAsync(CacheKeys.StockDetail(request.id), _IMapper.Map<StockDTO>(stock), TimeSpan.FromMinutes(5));
            return _IMapper.Map<StockDTO>(stock);
        }
    }
}

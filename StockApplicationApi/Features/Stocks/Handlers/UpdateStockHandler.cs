using AutoMapper;
using MediatR;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class UpdateStockHandler: IRequestHandler<UpdateStockCommand, StockDTO>
    {
        private readonly IStock _IStock;
        private readonly ILogger<UpdateStockHandler> _logger;
        private readonly IRedisService _cache;
        private readonly IMapper _IMapper;
     
        public UpdateStockHandler(IStock IStock, ILogger<UpdateStockHandler> logger, IRedisService cache, IMapper mapper)
        {
            _IStock = IStock;
            _logger = logger;
            _cache = cache;
            _IMapper = mapper;
        }

      
        public async Task<StockDTO> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            if (!request.isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to update stock with ID: {StockId}", request.id);
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }

            var existingStock = await _IStock.GetStock(u => u.Id == request.id, tracking: true);
            if (existingStock == null)
            {
                _logger.LogWarning("Attempt to update a non-existent stock with ID: {StockId}", request.id);
                throw new NotFoundException("Does this Stock exists?");
            }
            _IMapper.Map(request.stock, existingStock);

            await _IStock.UpdateStock(existingStock, cancellationToken);
            await _cache.RemoveDataAsync(CacheKeys.StockDetail(request.id));
            await _cache.RemoveByPrefixAsync(CacheKeys.StockList);
            _logger.LogInformation("Stock with ID: {StockId} updated successfully", request.id);

            return _IMapper.Map<StockDTO>(existingStock);
        }
    }
}

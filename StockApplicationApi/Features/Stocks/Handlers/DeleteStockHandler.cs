using MediatR;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Models;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand>
    {
        private readonly IRedisService _cache;
        private readonly ILogger<DeleteStockHandler> _logger;
        private readonly IStock _IStock;
        public DeleteStockHandler(IRedisService cache, ILogger<DeleteStockHandler> logger, IStock stock)
        {
            _cache = cache;
            _logger = logger;
            _IStock = stock;
        }
        public async Task Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            if (!request.isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to delete stock with ID: {StockId}", request.id);
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }
            var stock = await _IStock.GetStock(u => u.Id == request.id);
            if (stock == null)
            {
                _logger.LogWarning("Attempt to delete a non-existent stock with ID: {StockId}", request.id);
                throw new NotFoundException("Does this Stock exists?");

            }
            await _IStock.DeleteStock(stock, cancellationToken);

            await _cache.RemoveByPrefixAsync(CacheKeys.StockList);
            await _cache.RemoveDataAsync(CacheKeys.StockDetail(request.id));
            _logger.LogInformation("Cache removed successfully after deleting stock with ID: {StockId}", request.id);
        }
    }
}

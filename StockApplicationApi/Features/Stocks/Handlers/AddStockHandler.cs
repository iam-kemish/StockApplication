using AutoMapper;
using MediatR;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class AddStockHandler: IRequestHandler<AddStockCommand, StockDTO>
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly ILogger<AddStockHandler> _logger;
        private readonly IRedisService _cache;
        public AddStockHandler(IStock IStock, IMapper IMapper, ILogger<AddStockHandler> logger, IRedisService cache)
        {
            _IStock = IStock;
            _IMapper = IMapper;
            _logger = logger;
            _cache = cache;
        }
        public async Task<StockDTO> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            if (!request.isAdmin)
            {
                _logger.LogWarning("Unauthorized attempt to add stock");
                throw new UnAuthorizedException("Access Denied: You do not have the Admin role required for this action.");
            }
            var existing = await _IStock.GetStock(u =>
                u.CompanyName.ToLower() == request.stock.CompanyName.ToLower() ||
                u.Symbol.ToLower() == request.stock.Symbol.ToLower());

            if (existing != null)
            {

                string conflictDetail = "";

                if (existing.CompanyName.Equals(request.stock.CompanyName, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Company Name '{request.stock.CompanyName}'";
                else if (existing.Symbol.Equals(request.stock.Symbol, StringComparison.OrdinalIgnoreCase))
                    conflictDetail = $"Symbol '{request.stock.Symbol}'";

                _logger.LogWarning("Conflict detected: {ConflictDetail}", conflictDetail);


                throw new ConflictException($"{conflictDetail} already exists in our records.");
            }
            var createdStock = _IMapper.Map<Stock>(request.stock);
            await _IStock.AddStock(createdStock);
            await _cache.RemoveByPrefixAsync(CacheKeys.StockList);
            _logger.LogInformation("Stock created and removed cache successfully: {CompanyName}", request.stock.CompanyName);
            return _IMapper.Map<StockDTO>(createdStock);
        }
    }
}

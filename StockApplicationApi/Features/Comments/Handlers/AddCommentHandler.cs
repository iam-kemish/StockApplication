using AutoMapper;
using MediatR;
using StackExchange.Redis;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Comments.Commands;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Comments.Handlers
{
    public class AddCommentHandler: IRequestHandler<AddCommentCommand, CommentDto>
    {
        private readonly IComment _IComment;
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
        private readonly ILogger<AddCommentHandler> _logger;
        private readonly IRedisService _cache;
        public AddCommentHandler(IComment IComment, IStock IStock, IMapper IMapper, ILogger<AddCommentHandler> logger, IRedisService cache)
        {
            _IComment = IComment;
            _IStock = IStock;
            _IMapper = IMapper;
            _logger = logger;
            _cache = cache;
        }

        public async  Task<CommentDto> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsCustomer)
            {
                _logger.LogWarning("Unauthorized attempt to add stock");
                throw new UnAuthorizedException("Access Denied: You do not have the Customer  role required for this action.");
            }
            if (!await _IStock.StockExists(request.StockId))
            {
                _logger.LogWarning("Attempt to add comment for non-existing stockId: {StockId} by User: {UserId}", request.StockId, request.UserId);
                throw new ConflictException("This stock doesnt exist in stock database");
            }
            var createdComment = _IMapper.Map<Comment>(request.Comment);
            createdComment.StockId = request.StockId;
            createdComment.AppUserId = request.UserId;
            await _IComment.AddComment(createdComment);
            await _cache.RemoveByPrefixAsync(CacheKeys.CommentList);
            _logger.LogInformation("Comment added for stockId: {StockId} by User: {UserId}", request.StockId, request.UserId);
            return _IMapper.Map<CommentDto>(createdComment);
        }
    }
}

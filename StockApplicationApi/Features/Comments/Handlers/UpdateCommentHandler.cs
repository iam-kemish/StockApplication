using AutoMapper;
using MediatR;
using StackExchange.Redis;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Comments.Commands;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Stocks.Handlers
{
    public class UpdateCommentHandler: IRequestHandler<UpdateCommentCommand, CommentDto>
    {
        private readonly IComment _IComment;
        private readonly ILogger<UpdateCommentHandler> _logger;
        private readonly IRedisService _IRedis;
        private readonly IMapper _IMapper;
     
        public UpdateCommentHandler(IComment comment, ILogger<UpdateCommentHandler> logger, IRedisService cache, IMapper mapper)
        {
            _IComment = comment;
            _logger = logger;
            _IRedis = cache;
            _IMapper = mapper;
        }

      
        public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var existingComment = await _IComment.GetComment(u => u.Id == request.id, tracking: true);

            if (existingComment == null)
            {

                _logger.LogWarning("Attempt to update non-existing comment with id: {CommentId} by User: {UserId}", request.id,request.userId );

                throw new NotFoundException("Does this Comment exists?");
            }
            if (existingComment.AppUserId != request.userId)
            {
                _logger.LogWarning("User: {UserId} attempted to update comment with id: {CommentId} without permission", request.userId, request.id);
                throw new UnAuthorizedException("You are unauthorised.");
            }
            if (!request.isCustomer)
            {
                _logger.LogWarning("Unauthorized attempt to update comment with id: {CommentId} by User: {UserId}", request.id, request.userId);
                throw new UnAuthorizedException("Access Denied: You do not have the Customer role required for this action.");
            }

            existingComment.Title = request.comment.Title;
            existingComment.Content = request.comment.Content;


            await _IComment.UpdateComment(existingComment);
            await _IRedis.RemoveByPrefixAsync(CacheKeys.CommentList);
            await _IRedis.RemoveDataAsync(CacheKeys.CommentDetail(request.id));
            _logger.LogInformation("Comment with id: {CommentId} updated successfully", request.id);

            return _IMapper.Map<CommentDto>(existingComment);
        }
    }
}

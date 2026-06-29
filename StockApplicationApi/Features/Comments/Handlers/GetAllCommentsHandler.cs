using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using StockApplicationApi.Features.Comments.Queries;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Comments.Handlers
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly IComment _IComment;
        private readonly IMapper _IMapper;
        private readonly ILogger<GetAllCommentsHandler> _logger;
        private readonly IRedisService _IRedis;

        public GetAllCommentsHandler(IComment IComment, IMapper IMapper, ILogger<GetAllCommentsHandler> logger, IRedisService IRedis)
        {
            _IComment = IComment;
            _IMapper = IMapper;
            _logger = logger;
            _IRedis = IRedis;
        }
        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving all comments");
            var comments = await _IComment.GetAllComments(cancellationToken: cancellationToken);
            await _IRedis.SetDataAsync(CacheKeys.CommentList, comments, TimeSpan.FromMinutes(10));
            return _IMapper.Map<IEnumerable<CommentDto>>(comments);
        }
    }
}

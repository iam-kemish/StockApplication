using AutoMapper;
using MediatR;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Features.Comments.Queries;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Features.Comments.Handlers
{
    public class GetCommentByIdHandler:IRequestHandler<GetCommentById, CommentDto>
    {
        private readonly IComment _IComment;
        private readonly IMapper _IMapper;
        
        private readonly ILogger<GetCommentByIdHandler> _logger;
        private readonly IRedisService _IRedis;
        public GetCommentByIdHandler(IComment IComment, IMapper IMapper, ILogger<GetCommentByIdHandler> logger, IRedisService IRedis)
        {
            _IComment = IComment;
            _IMapper = IMapper;
          
            _logger = logger;
            _IRedis = IRedis;
        }

        public async Task<CommentDto> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving comment with id: {CommentId}", request.id);
            var comment = await _IComment.GetComment(u => u.Id == request.id, cancellationToken: cancellationToken);
            if (comment == null)
            {
                _logger.LogWarning("Comment with id: {CommentId} not found", request.id);
                throw new NotFoundException("Does this Comment exists?");
            }
            await _IRedis.SetDataAsync(CacheKeys.CommentDetail(request.id), comment, TimeSpan.FromMinutes(10));
            return _IMapper.Map<CommentDto>(comment);
        }
    }
}

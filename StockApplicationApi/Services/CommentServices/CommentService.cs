using AutoMapper;
using FluentValidation;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.RedisService;
using static StockApplicationApi.Helpers.RedisCacheStrings;

namespace StockApplicationApi.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IComment _IComment;
        private readonly IMapper _IMapper;
        private readonly IStock _IStock;
        private readonly ILogger<CommentService> _logger;
        private readonly IRedisService _IRedis;

        public CommentService(IComment comment ,IMapper mapper, IStock stock, ILogger<CommentService> logger, IRedisService redisService)
        {
            _IComment = comment;
            _IMapper = mapper;
            _IStock = stock;
            _logger = logger;
            _IRedis = redisService;
        
        }
        public async Task<CommentDto> AddComment(CreateComment comment, int stockId)
        {
         if ( !await _IStock.StockExists(stockId))
            {
                _logger.LogWarning("Attempt to add comment for non-existing stockId: {StockId}", stockId);
                throw new ConflictException("This stock doesnt exist in stock database");
            }
            var createdComment = _IMapper.Map<Comment>(comment);
            createdComment.StockId = stockId;
            await _IComment.AddComment(createdComment);
            await _IRedis.RemoveByPrefixAsync(CacheKeys.CommentList); 
            _logger.LogInformation("Comment added for stockId: {StockId}", stockId);
            return _IMapper.Map<CommentDto>(createdComment);
        }


        public async Task<IEnumerable<CommentDto>> GetAllComments()
        {
            
            _logger.LogInformation("Retrieving all comments");
            var comments = await  _IComment.GetAllComments();
            await _IRedis.SetDataAsync(CacheKeys.CommentList, comments, TimeSpan.FromMinutes(10));
            return  _IMapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentById(int id)
        {
            _logger.LogInformation("Retrieving comment with id: {CommentId}", id);
            var comment = await _IComment.GetComment(u => u.Id == id);
            if (comment == null)
            {
                _logger.LogWarning("Comment with id: {CommentId} not found", id);
                throw new NotFoundException("does this stock exists?");
            }
            await _IRedis.SetDataAsync(CacheKeys.CommentDetail(id), comment, TimeSpan.FromMinutes(10));
            return _IMapper.Map<CommentDto>(comment);
        }

        public async Task<CommentDto> UpdateComment(int id, CommentUpdateDTO comment)
        {
            var existingComment = await _IComment.GetComment(u=>u.Id == id, tracking: true);
            if (existingComment == null)
            {

                _logger.LogWarning("Attempt to update non-existing comment with id: {CommentId}", id);
             
                throw new NotFoundException("Does this Comment exists?");
            }


            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;
            

            await _IComment.UpdateComment(existingComment);
            await _IRedis.RemoveByPrefixAsync(CacheKeys.CommentList);
            await _IRedis.RemoveDataAsync(CacheKeys.CommentDetail(id));
            _logger.LogInformation("Comment with id: {CommentId} updated successfully", id);

            return _IMapper.Map<CommentDto>(existingComment);
        }
    }
}

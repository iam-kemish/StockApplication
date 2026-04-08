using AutoMapper;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;

namespace StockApplicationApi.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IComment _IComment;
        private readonly IMapper _IMapper;
        private readonly IStock _IStock;

        public CommentService(IComment comment ,IMapper mapper, IStock stock)
        {
            _IComment = comment;
            _IMapper = mapper;
            _IStock = stock;
         
        }
        public async Task<CommentDto> AddComment(CreateComment comment)
        {
         if ( !await _IStock.StockExists(comment.StockId))
            {
                throw new ConflictException("This stock doesnt exist in stock database");
            }
            var createdComment = _IMapper.Map<Comment>(comment);
            await _IComment.AddComment(createdComment);

            return _IMapper.Map<CommentDto>(createdComment);
        }

        public async Task<IEnumerable<CommentDto>> GetAllComments()
        {
          var comments = await  _IComment.GetAllComments();
          return  _IMapper.Map<IEnumerable<CommentDto>>(comments);
        }
    }
}

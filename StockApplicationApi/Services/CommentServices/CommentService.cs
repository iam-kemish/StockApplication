using AutoMapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Repositary.CommentRepositary;

namespace StockApplicationApi.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IComment _IComment;
        private readonly IMapper _IMapper;

        public CommentService(IComment comment ,IMapper mapper)
        {
            _IComment = comment;
            _IMapper = mapper;
        }
        public async Task<CommentDto> AddComment(CreateComment comment)
        {
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

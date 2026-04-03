using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllComments();
        Task<CommentDto> AddComment(CreateComment comment);
    }
}

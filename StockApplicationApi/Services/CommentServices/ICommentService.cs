using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllComments();
        Task<CommentDto> GetCommentById(int id);
        Task<CommentDto> AddComment(CreateComment comment);
        Task<CommentDto> UpdateComment(int id, CommentUpdateDTO comment);
    }
}

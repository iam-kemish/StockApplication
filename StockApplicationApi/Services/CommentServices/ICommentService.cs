using StockApplicationApi.Models.DTOs.CommentDTOs;

namespace StockApplicationApi.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllComments();
        Task<CommentDto> GetCommentById(int id);
        Task<CommentDto> AddComment(CreateComment comment, int stockId, string userId);
        Task<CommentDto> UpdateComment(int id, CommentUpdateDTO comment,string userId);
    }
}

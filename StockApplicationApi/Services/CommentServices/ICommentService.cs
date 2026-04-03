using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Services.CommentServices
{
    public interface ICommentService
    {
        Task<StockDTO> AddComment(CreateComment comment);
    }
}

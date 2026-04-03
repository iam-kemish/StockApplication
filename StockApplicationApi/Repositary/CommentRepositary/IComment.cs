using StockApplicationApi.Models;

namespace StockApplicationApi.Repositary.CommentRepositary
{
    public interface IComment
    {
        Task AddComment(Comment comment);
    }
}

using StockApplicationApi.Models;
using System.Linq.Expressions;

namespace StockApplicationApi.Repositary.CommentRepositary
{
    public interface IComment
    {
        Task<IEnumerable<Comment>> GetAllComments(Expression<Func<Comment, bool>>? filter = null);
        Task AddComment(Comment comment);
    }
}

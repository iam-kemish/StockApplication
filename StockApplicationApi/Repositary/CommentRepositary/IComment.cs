using StockApplicationApi.Models;
using System.Linq.Expressions;

namespace StockApplicationApi.Repositary.CommentRepositary
{
    public interface IComment
    {
        Task<IEnumerable<Comment>> GetAllComments(Expression<Func<Comment, bool>>? filter = null, CancellationToken cancellationToken = default);

        Task<Comment?> GetComment(Expression<Func<Comment, bool>>? filter = null, bool tracking = false, CancellationToken cancellationToken = default);
        Task AddComment(Comment comment, CancellationToken cancellationToken = default);
       
        Task UpdateComment(Comment comment, CancellationToken cancellationToken = default);
    }
}

using StockApplicationApi.Database;
using StockApplicationApi.Models;

namespace StockApplicationApi.Repositary.CommentRepositary
{
    public class CommentClass : IComment
    {
        private readonly AppDbContext _context;
        public CommentClass(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Database;
using StockApplicationApi.Models;
using System.Linq;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<Comment>> GetAllComments(Expression<Func<Comment, bool>>? filter = null)
        {
            var query = _context.Comments.AsNoTracking().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public Task<Comment?> GetComment(Expression<Func<Comment, bool>>? filter = null)
        {
            var query = _context.Comments.AsNoTracking().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefaultAsync();
        }

       
        public async Task<Comment?> GetCommentForUpdate(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task UpdateComment()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}

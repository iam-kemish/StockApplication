using Microsoft.EntityFrameworkCore;
using StockApplication.Models;

namespace StockApplication.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions DbContextOptions): base(DbContextOptions)
        {
            
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

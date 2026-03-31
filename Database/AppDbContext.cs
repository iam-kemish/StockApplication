using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Models;

namespace StockApplicationApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Symbol = "AAPL",
                    CompanyName = "Apple Inc",
                    Purchase = 175.50m,
                    LastDiv = 0.24m,
                    Industry = "Technology",
                    MarketCap = 2800000000000
                },
               new Stock
               {
                   Id = 2,
                   Symbol = "MSFT",
                   CompanyName = "Microsoft",
                   Purchase = 320.10m,
                   LastDiv = 0.68m,
                   Industry = "Technology",
                   MarketCap = 3000000000000
               },
                new Stock
                {
                    Id = 3,
                    Symbol = "GOOGL",
                    CompanyName = "Alphabet",
                    Purchase = 140.25m,
                    LastDiv = 0.00m,
                    Industry = "Technology",
                    MarketCap = 1800000000000
                },
                 new Stock
                 {
                     Id = 4,
                     Symbol = "AMZN",
                     CompanyName = "Amazon",
                     Purchase = 155.80m,
                     LastDiv = 0.00m,
                     Industry = "E-Commerce",
                     MarketCap = 1600000000000
                 },
                new Stock
                {
                    Id = 5,
                    Symbol = "TSLA",
                    CompanyName = "Tesla",
                    Purchase = 210.40m,
                    LastDiv = 0.00m,
                    Industry = "Automotive",
                    MarketCap = 700000000000
                },
                 new Stock
                 {
                     Id = 6,
                     Symbol = "NVDA",
                     CompanyName = "Nvidia",
                     Purchase = 600.75m,
                     LastDiv = 0.16m,
                     Industry = "Semiconductors",
                     MarketCap = 2200000000000
                 });
                }
    }
}
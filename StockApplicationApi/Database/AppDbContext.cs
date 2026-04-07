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

            modelBuilder.Entity<Comment>().HasData(
       // Apple
       new Comment
       {
           Id = 1,
           Title = "Strong Ecosystem",
           Content = "Apple has one of the strongest ecosystems with loyal customers.",
           CreatedOn = new DateTime(2024, 1, 1),
           StockId = 1
       },
       new Comment
       {
           Id = 2,
           Title = "Stable Growth",
           Content = "Consistent performance and reliable dividends.",
           CreatedOn = new DateTime(2024, 1, 2),
           StockId = 1
       },

       // Microsoft
       new Comment
       {
           Id = 3,
           Title = "Cloud Dominance",
           Content = "Azure is driving massive growth for Microsoft.",
           CreatedOn = new DateTime(2024, 1, 3),
           StockId = 2
       },
       new Comment
       {
           Id = 4,
           Title = "AI Leader",
           Content = "Microsoft is leading in AI with OpenAI partnerships.",
           CreatedOn = new DateTime(2024, 1, 4),
           StockId = 2
       },

       // Google
       new Comment
       {
           Id = 5,
           Title = "Ad Revenue Giant",
           Content = "Google still dominates digital advertising.",
           CreatedOn = new DateTime(2024, 1, 5),
           StockId = 3
       },
       new Comment
       {
           Id = 6,
           Title = "Search King",
           Content = "Search engine monopoly keeps revenue stable.",
           CreatedOn = new DateTime(2024, 1, 6),
           StockId = 3
       },

       // Amazon
       new Comment
       {
           Id = 7,
           Title = "E-commerce Leader",
           Content = "Amazon dominates global online retail.",
           CreatedOn = new DateTime(2024, 1, 7),
           StockId = 4
       },
       new Comment
       {
           Id = 8,
           Title = "AWS Power",
           Content = "AWS contributes a huge portion of profits.",
           CreatedOn = new DateTime(2024, 1, 8),
           StockId = 4
       },

       // Tesla
       new Comment
       {
           Id = 9,
           Title = "EV Pioneer",
           Content = "Tesla is leading the electric vehicle revolution.",
           CreatedOn = new DateTime(2024, 1, 9),
           StockId = 5
       },
       new Comment
       {
           Id = 10,
           Title = "High Volatility",
           Content = "Stock is highly volatile but has big growth potential.",
           CreatedOn = new DateTime(2024, 1, 10),
           StockId = 5
       },

       // Nvidia
       new Comment
       {
           Id = 11,
           Title = "AI Boom",
           Content = "Nvidia is benefiting massively from AI demand.",
           CreatedOn = new DateTime(2024, 1, 11),
           StockId = 6
       },
       new Comment
       {
           Id = 12,
           Title = "GPU Leader",
           Content = "Top player in GPUs for gaming and data centers.",
           CreatedOn = new DateTime(2024, 1, 12),
           StockId = 6
       }
   );
        }
    }
}
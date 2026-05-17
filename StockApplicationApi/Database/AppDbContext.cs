using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Models;
using StockApplicationApi.Models.RefreshTokens;

namespace StockApplicationApi.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<AppUser> AppUsers { get; set; } 
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>()
                 
                .HasData(
                 new Stock { Id = 1, Symbol = "NVDA", CompanyName = "Nvidia", Purchase = 188.60m, LastDiv = 0.16m, Industry = "Semiconductors", MarketCap = 4300000000000 },
                new Stock { Id = 2, Symbol = "AAPL", CompanyName = "Apple Inc", Purchase = 260.45m, LastDiv = 0.24m, Industry = "Technology", MarketCap = 3800000000000 },
                new Stock { Id = 3, Symbol = "GOOGL", CompanyName = "Alphabet", Purchase = 315.70m, LastDiv = 0.00m, Industry = "Technology", MarketCap = 3700000000000 },
                new Stock { Id = 4, Symbol = "MSFT", CompanyName = "Microsoft", Purchase = 370.80m, LastDiv = 0.68m, Industry = "Technology", MarketCap = 2800000000000 },
                new Stock { Id = 5, Symbol = "AMZN", CompanyName = "Amazon", Purchase = 238.40m, LastDiv = 0.00m, Industry = "E-Commerce", MarketCap = 2600000000000 },
                new Stock { Id = 6, Symbol = "TSM", CompanyName = "TSMC", Purchase = 370.60m, LastDiv = 1.20m, Industry = "Semiconductors", MarketCap = 1900000000000 },
                new Stock { Id = 7, Symbol = "AVGO", CompanyName = "Broadcom", Purchase = 371.50m, LastDiv = 2.10m, Industry = "Semiconductors", MarketCap = 1800000000000 },
                new Stock { Id = 8, Symbol = "META", CompanyName = "Meta Platforms", Purchase = 629.80m, LastDiv = 0.50m, Industry = "Social Media", MarketCap = 1600000000000 },
                new Stock { Id = 9, Symbol = "TSLA", CompanyName = "Tesla", Purchase = 348.90m, LastDiv = 0.00m, Industry = "Automotive", MarketCap = 1300000000000 },
                new Stock { Id = 10, Symbol = "BRK-B", CompanyName = "Berkshire Hathaway", Purchase = 479.90m, LastDiv = 0.00m, Industry = "Financials", MarketCap = 1030000000000 },
                new Stock { Id = 11, Symbol = "WMT", CompanyName = "Walmart", Purchase = 126.70m, LastDiv = 0.80m, Industry = "Retail", MarketCap = 1010000000000 },
                new Stock { Id = 12, Symbol = "LLY", CompanyName = "Eli Lilly", Purchase = 939.40m, LastDiv = 1.30m, Industry = "Healthcare", MarketCap = 887000000000 },
                new Stock { Id = 13, Symbol = "JPM", CompanyName = "JPMorgan Chase", Purchase = 309.80m, LastDiv = 1.15m, Industry = "Financials", MarketCap = 835000000000 },
                new Stock { Id = 14, Symbol = "V", CompanyName = "Visa", Purchase = 304.30m, LastDiv = 0.52m, Industry = "Financials", MarketCap = 586000000000 },
                new Stock { Id = 15, Symbol = "XOM", CompanyName = "Exxon Mobil", Purchase = 152.50m, LastDiv = 0.95m, Industry = "Energy", MarketCap = 633000000000 },
                new Stock { Id = 16, Symbol = "ASML", CompanyName = "ASML Holding", Purchase = 1478.00m, LastDiv = 1.75m, Industry = "Semiconductors", MarketCap = 580000000000 },
                new Stock { Id = 17, Symbol = "TCEHY", CompanyName = "Tencent", Purchase = 63.90m, LastDiv = 0.40m, Industry = "Technology", MarketCap = 578000000000 },
                new Stock { Id = 18, Symbol = "JNJ", CompanyName = "Johnson & Johnson", Purchase = 238.40m, LastDiv = 1.19m, Industry = "Healthcare", MarketCap = 574000000000 },
                new Stock { Id = 19, Symbol = "MA", CompanyName = "Mastercard", Purchase = 498.60m, LastDiv = 0.66m, Industry = "Financials", MarketCap = 445000000000 },
                new Stock { Id = 20, Symbol = "COST", CompanyName = "Costco", Purchase = 998.40m, LastDiv = 1.02m, Industry = "Retail", MarketCap = 443000000000 },
                new Stock { Id = 21, Symbol = "NFLX", CompanyName = "Netflix", Purchase = 103.00m, LastDiv = 0.00m, Industry = "Entertainment", MarketCap = 436000000000 },
                new Stock { Id = 22, Symbol = "AMD", CompanyName = "AMD", Purchase = 245.00m, LastDiv = 0.00m, Industry = "Semiconductors", MarketCap = 399000000000 },
                new Stock { Id = 23, Symbol = "ORCL", CompanyName = "Oracle", Purchase = 138.00m, LastDiv = 0.40m, Industry = "Software", MarketCap = 397000000000 },
                new Stock { Id = 24, Symbol = "CVX", CompanyName = "Chevron", Purchase = 188.50m, LastDiv = 1.51m, Industry = "Energy", MarketCap = 375000000000 },
                new Stock { Id = 25, Symbol = "HD", CompanyName = "Home Depot", Purchase = 337.30m, LastDiv = 2.25m, Industry = "Retail", MarketCap = 335000000000 },
                new Stock { Id = 26, Symbol = "KO", CompanyName = "Coca-Cola", Purchase = 77.40m, LastDiv = 0.48m, Industry = "Beverages", MarketCap = 333000000000 },
                new Stock { Id = 27, Symbol = "ABBV", CompanyName = "AbbVie", Purchase = 207.90m, LastDiv = 1.55m, Industry = "Healthcare", MarketCap = 367000000000 },
                new Stock { Id = 28, Symbol = "BAC", CompanyName = "Bank of America", Purchase = 52.50m, LastDiv = 0.24m, Industry = "Financials", MarketCap = 377000000000 },
                new Stock { Id = 29, Symbol = "PG", CompanyName = "Procter & Gamble", Purchase = 145.10m, LastDiv = 0.94m, Industry = "Consumer Goods", MarketCap = 339000000000 },
                new Stock { Id = 30, Symbol = "PEP", CompanyName = "PepsiCo", Purchase = 168.20m, LastDiv = 1.26m, Industry = "Beverages", MarketCap = 231000000000 },
                new Stock { Id = 31, Symbol = "CRM", CompanyName = "Salesforce", Purchase = 295.40m, LastDiv = 0.40m, Industry = "Software", MarketCap = 285000000000 },
                new Stock { Id = 32, Symbol = "ADBE", CompanyName = "Adobe", Purchase = 585.10m, LastDiv = 0.00m, Industry = "Software", MarketCap = 262000000000 },
                new Stock { Id = 33, Symbol = "NKE", CompanyName = "Nike", Purchase = 101.50m, LastDiv = 0.37m, Industry = "Apparel", MarketCap = 153000000000 },
                new Stock { Id = 34, Symbol = "DIS", CompanyName = "Disney", Purchase = 112.80m, LastDiv = 0.30m, Industry = "Entertainment", MarketCap = 205000000000 },
                new Stock { Id = 35, Symbol = "TM", CompanyName = "Toyota", Purchase = 210.60m, LastDiv = 0.85m, Industry = "Automotive", MarketCap = 274000000000 },
                new Stock { Id = 36, Symbol = "AZN", CompanyName = "AstraZeneca", Purchase = 204.00m, LastDiv = 1.90m, Industry = "Healthcare", MarketCap = 316000000000 },
                new Stock { Id = 37, Symbol = "INTC", CompanyName = "Intel", Purchase = 62.30m, LastDiv = 0.12m, Industry = "Semiconductors", MarketCap = 313000000000 },
                new Stock { Id = 38, Symbol = "PLTR", CompanyName = "Palantir", Purchase = 128.00m, LastDiv = 0.00m, Industry = "Software", MarketCap = 306000000000 },
                new Stock { Id = 39, Symbol = "BABA", CompanyName = "Alibaba", Purchase = 127.30m, LastDiv = 0.00m, Industry = "E-Commerce", MarketCap = 304000000000 },
                new Stock { Id = 40, Symbol = "PFE", CompanyName = "Pfizer", Purchase = 28.50m, LastDiv = 0.42m, Industry = "Healthcare", MarketCap = 161000000000 },
                new Stock { Id = 41, Symbol = "CAT", CompanyName = "Caterpillar", Purchase = 790.60m, LastDiv = 1.30m, Industry = "Industrials", MarketCap = 370000000000 },
                new Stock { Id = 42, Symbol = "CSCO", CompanyName = "Cisco", Purchase = 82.20m, LastDiv = 0.40m, Industry = "Technology", MarketCap = 324000000000 },
                new Stock { Id = 43, Symbol = "IBM", CompanyName = "IBM", Purchase = 185.30m, LastDiv = 1.66m, Industry = "Technology", MarketCap = 170000000000 },
                new Stock { Id = 44, Symbol = "GS", CompanyName = "Goldman Sachs", Purchase = 907.80m, LastDiv = 2.75m, Industry = "Financials", MarketCap = 269000000000 },
                new Stock { Id = 45, Symbol = "MCD", CompanyName = "McDonald's", Purchase = 290.40m, LastDiv = 1.67m, Industry = "Restaurants", MarketCap = 210000000000 },
                new Stock { Id = 46, Symbol = "SBUX", CompanyName = "Starbucks", Purchase = 92.50m, LastDiv = 0.57m, Industry = "Restaurants", MarketCap = 105000000000 },
                new Stock { Id = 47, Symbol = "UPS", CompanyName = "UPS", Purchase = 145.80m, LastDiv = 1.63m, Industry = "Logistics", MarketCap = 125000000000 },
                new Stock { Id = 48, Symbol = "BX", CompanyName = "Blackstone", Purchase = 130.20m, LastDiv = 0.82m, Industry = "Financials", MarketCap = 158000000000 },
                new Stock { Id = 49, Symbol = "QCOM", CompanyName = "Qualcomm", Purchase = 170.50m, LastDiv = 0.80m, Industry = "Semiconductors", MarketCap = 190000000000 },
                new Stock { Id = 50, Symbol = "ABT", CompanyName = "Abbott Labs", Purchase = 115.40m, LastDiv = 0.55m, Industry = "Healthcare", MarketCap = 201000000000 }
                );

                modelBuilder.Entity<Comment>()
                    .HasOne(c => c.AppUser)
                    .WithMany(s => s.Comments)
                    .HasForeignKey(c => c.AppUserId);

                modelBuilder.Entity<Comment>()
                    .HasOne(c => c.Stock)
                    .WithMany(s => s.Comments)
                    .HasForeignKey(c => c.StockId);
        }
    }
}
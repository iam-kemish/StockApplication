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
                 .HasIndex(s => s.Symbol);

              modelBuilder.Entity<Stock>().HasData(
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
                new Stock { Id = 50, Symbol = "ABT", CompanyName = "Abbott Labs", Purchase = 115.40m, LastDiv = 0.55m, Industry = "Healthcare", MarketCap = 201000000000 },
                new Stock { Id = 51, Symbol = "UNH", CompanyName = "UnitedHealth Group", Purchase = 580.20m, LastDiv = 2.10m, Industry = "Healthcare", MarketCap = 530000000000 },
                new Stock { Id = 52, Symbol = "NOW", CompanyName = "ServiceNow", Purchase = 890.40m, LastDiv = 0.00m, Industry = "Software", MarketCap = 185000000000 },
                new Stock { Id = 53, Symbol = "GE", CompanyName = "GE Aerospace", Purchase = 175.80m, LastDiv = 0.28m, Industry = "Aerospace", MarketCap = 192000000000 },
                new Stock { Id = 54, Symbol = "AMAT", CompanyName = "Applied Materials", Purchase = 210.30m, LastDiv = 0.40m, Industry = "Semiconductors", MarketCap = 172000000000 },
                new Stock { Id = 55, Symbol = "ISRG", CompanyName = "Intuitive Surgical", Purchase = 460.50m, LastDiv = 0.00m, Industry = "Healthcare", MarketCap = 164000000000 },
                new Stock { Id = 56, Symbol = "BKNG", CompanyName = "Booking Holdings", Purchase = 4200.00m, LastDiv = 8.75m, Industry = "Travel", MarketCap = 145000000000 },
                new Stock { Id = 57, Symbol = "TXN", CompanyName = "Texas Instruments", Purchase = 205.10m, LastDiv = 1.30m, Industry = "Semiconductors", MarketCap = 188000000000 },
                new Stock { Id = 58, Symbol = "LRCX", CompanyName = "Lam Research", Purchase = 820.70m, LastDiv = 2.30m, Industry = "Semiconductors", MarketCap = 106000000000 },
                new Stock { Id = 59, Symbol = "SPGI", CompanyName = "S&P Global", Purchase = 510.80m, LastDiv = 0.91m, Industry = "Financials", MarketCap = 159000000000 },
                new Stock { Id = 60, Symbol = "SYK", CompanyName = "Stryker", Purchase = 365.40m, LastDiv = 0.80m, Industry = "Healthcare", MarketCap = 139000000000 },
                new Stock { Id = 61, Symbol = "PANW", CompanyName = "Palo Alto Networks", Purchase = 345.90m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 112000000000 },
                new Stock { Id = 62, Symbol = "ANET", CompanyName = "Arista Networks", Purchase = 325.00m, LastDiv = 0.00m, Industry = "Networking", MarketCap = 102000000000 },
                new Stock { Id = 63, Symbol = "MU", CompanyName = "Micron Technology", Purchase = 130.40m, LastDiv = 0.11m, Industry = "Semiconductors", MarketCap = 144000000000 },
                new Stock { Id = 64, Symbol = "ADP", CompanyName = "Automatic Data Processing", Purchase = 275.60m, LastDiv = 1.40m, Industry = "Software", MarketCap = 113000000000 },
                new Stock { Id = 65, Symbol = "TJX", CompanyName = "TJX Companies", Purchase = 118.90m, LastDiv = 0.38m, Industry = "Retail", MarketCap = 133000000000 },
                new Stock { Id = 66, Symbol = "MDLZ", CompanyName = "Mondelez International", Purchase = 72.30m, LastDiv = 0.47m, Industry = "Consumer Goods", MarketCap = 97000000000 },
                new Stock { Id = 67, Symbol = "FI", CompanyName = "Fiserv", Purchase = 178.50m, LastDiv = 0.00m, Industry = "Financials", MarketCap = 105000000000 },
                new Stock { Id = 68, Symbol = "SCHW", CompanyName = "Charles Schwab", Purchase = 68.40m, LastDiv = 0.25m, Industry = "Financials", MarketCap = 124000000000 },
                new Stock { Id = 69, Symbol = "PGR", CompanyName = "Progressive", Purchase = 245.80m, LastDiv = 0.10m, Industry = "Insurance", MarketCap = 144000000000 },
                new Stock { Id = 70, Symbol = "UBER", CompanyName = "Uber Technologies", Purchase = 78.90m, LastDiv = 0.00m, Industry = "Transportation", MarketCap = 163000000000 },
                new Stock { Id = 71, Symbol = "LLY", CompanyName = "Eli Lilly & Co", Purchase = 910.00m, LastDiv = 1.30m, Industry = "Healthcare", MarketCap = 860000000000 },
                new Stock { Id = 72, Symbol = "CB", CompanyName = "Chubb Limited", Purchase = 280.30m, LastDiv = 0.91m, Industry = "Insurance", MarketCap = 114000000000 },
                new Stock { Id = 73, Symbol = "DE", CompanyName = "John Deere", Purchase = 395.20m, LastDiv = 1.47m, Industry = "Industrials", MarketCap = 109000000000 },
                new Stock { Id = 74, Symbol = "SRE", CompanyName = "Sempra Energy", Purchase = 84.50m, LastDiv = 0.62m, Industry = "Utilities", MarketCap = 53000000000 },
                new Stock { Id = 75, Symbol = "MMCM", CompanyName = "Marsh McLennan", Purchase = 225.10m, LastDiv = 0.81m, Industry = "Insurance", MarketCap = 111000000000 },
                new Stock { Id = 76, Symbol = "REGN", CompanyName = "Regeneron Pharmaceuticals", Purchase = 1150.00m, LastDiv = 0.00m, Industry = "Healthcare", MarketCap = 123000000000 },
                new Stock { Id = 77, Symbol = "ADI", CompanyName = "Analog Devices", Purchase = 230.80m, LastDiv = 0.92m, Industry = "Semiconductors", MarketCap = 114000000000 },
                new Stock { Id = 78, Symbol = "KLAC", CompanyName = "KLA Corporation", Purchase = 815.40m, LastDiv = 1.45m, Industry = "Semiconductors", MarketCap = 109000000000 },
                new Stock { Id = 79, Symbol = "BSX", CompanyName = "Boston Scientific", Purchase = 82.60m, LastDiv = 0.00m, Industry = "Healthcare", MarketCap = 121000000000 },
                new Stock { Id = 80, Symbol = "WM", CompanyName = "Waste Management", Purchase = 215.30m, LastDiv = 0.75m, Industry = "Services", MarketCap = 86000000000 },
                new Stock { Id = 81, Symbol = "SHW", CompanyName = "Sherwin-Williams", Purchase = 360.20m, LastDiv = 0.71m, Industry = "Materials", MarketCap = 90000000000 },
                new Stock { Id = 82, Symbol = "HCA", CompanyName = "HCA Healthcare", Purchase = 380.50m, LastDiv = 0.66m, Industry = "Healthcare", MarketCap = 98000000000 },
                new Stock { Id = 83, Symbol = "ETN", CompanyName = "Eaton Corporation", Purchase = 330.10m, LastDiv = 0.94m, Industry = "Industrials", MarketCap = 131000000000 },
                new Stock { Id = 84, Symbol = "CRWD", CompanyName = "CrowdStrike", Purchase = 280.40m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 68000000000 },
                new Stock { Id = 85, Symbol = "SNPS", CompanyName = "Synopsys", Purchase = 580.90m, LastDiv = 0.00m, Industry = "Software", MarketCap = 89000000000 },
                new Stock { Id = 86, Symbol = "CDNS", CompanyName = "Cadence Design Systems", Purchase = 290.10m, LastDiv = 0.00m, Industry = "Software", MarketCap = 78000000000 },
                new Stock { Id = 87, Symbol = "MDT", CompanyName = "Medtronic", Purchase = 88.40m, LastDiv = 0.70m, Industry = "Healthcare", MarketCap = 113000000000 },
                new Stock { Id = 88, Symbol = "CI", CompanyName = "The Cigna Group", Purchase = 350.20m, LastDiv = 1.40m, Industry = "Healthcare", MarketCap = 99000000000 },
                new Stock { Id = 89, Symbol = "ECL", CompanyName = "Ecolab", Purchase = 250.60m, LastDiv = 0.57m, Industry = "Chemicals", MarketCap = 71000000000 },
                new Stock { Id = 90, Symbol = "ITW", CompanyName = "Illinois Tool Works", Purchase = 260.80m, LastDiv = 1.40m, Industry = "Industrials", MarketCap = 78000000000 },
                new Stock { Id = 91, Symbol = "PH", CompanyName = "Parker-Hannifin", Purchase = 590.20m, LastDiv = 1.63m, Industry = "Industrials", MarketCap = 75000000000 },
                new Stock { Id = 92, Symbol = "MCO", CompanyName = "Moody's Corporation", Purchase = 490.50m, LastDiv = 0.85m, Industry = "Financials", MarketCap = 89000000000 },
                new Stock { Id = 93, Symbol = "CSX", CompanyName = "CSX Corporation", Purchase = 35.10m, LastDiv = 0.12m, Industry = "Transportation", MarketCap = 68000000000 },
                new Stock { Id = 94, Symbol = "NSC", CompanyName = "Norfolk Southern", Purchase = 240.60m, LastDiv = 1.35m, Industry = "Transportation", MarketCap = 54000000000 },
                new Stock { Id = 95, Symbol = "FDX", CompanyName = "FedEx", Purchase = 285.30m, LastDiv = 1.38m, Industry = "Logistics", MarketCap = 70000000000 },
                new Stock { Id = 96, Symbol = "MCK", CompanyName = "McKesson Corporation", Purchase = 590.80m, LastDiv = 0.71m, Industry = "Healthcare", MarketCap = 76000000000 },
                new Stock { Id = 97, Symbol = "ORLY", CompanyName = "O'Reilly Automotive", Purchase = 1150.00m, LastDiv = 0.00m, Industry = "Retail", MarketCap = 67000000000 },
                new Stock { Id = 98, Symbol = "AZO", CompanyName = "AutoZone", Purchase = 3100.00m, LastDiv = 0.00m, Industry = "Retail", MarketCap = 52000000000 },
                new Stock { Id = 99, Symbol = "MAR", CompanyName = "Marriott International", Purchase = 250.40m, LastDiv = 0.63m, Industry = "Hospitality", MarketCap = 71000000000 },
                new Stock { Id = 100, Symbol = "HLT", CompanyName = "Hilton Worldwide", Purchase = 220.10m, LastDiv = 0.15m, Industry = "Hospitality", MarketCap = 55000000000 },

                // 101–150
                new Stock { Id = 101, Symbol = "SHOP", CompanyName = "Shopify", Purchase = 78.50m, LastDiv = 0.00m, Industry = "E-Commerce", MarketCap = 101000000000 },
                new Stock { Id = 102, Symbol = "SQ", CompanyName = "Block Inc", Purchase = 68.20m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 42000000000 },
                new Stock { Id = 103, Symbol = "PYPL", CompanyName = "PayPal", Purchase = 72.40m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 74000000000 },
                new Stock { Id = 104, Symbol = "COIN", CompanyName = "Coinbase", Purchase = 220.10m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 54000000000 },
                new Stock { Id = 105, Symbol = "SPOT", CompanyName = "Spotify", Purchase = 340.60m, LastDiv = 0.00m, Industry = "Entertainment", MarketCap = 68000000000 },
                new Stock { Id = 106, Symbol = "SNOW", CompanyName = "Snowflake", Purchase = 125.30m, LastDiv = 0.00m, Industry = "Software", MarketCap = 41000000000 },
                new Stock { Id = 107, Symbol = "DDOG", CompanyName = "DataDog", Purchase = 118.40m, LastDiv = 0.00m, Industry = "Software", MarketCap = 39000000000 },
                new Stock { Id = 108, Symbol = "NET", CompanyName = "Cloudflare", Purchase = 82.10m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 28000000000 },
                new Stock { Id = 109, Symbol = "ZS", CompanyName = "Zscaler", Purchase = 190.50m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 29000000000 },
                new Stock { Id = 110, Symbol = "TWLO", CompanyName = "Twilio", Purchase = 62.80m, LastDiv = 0.00m, Industry = "Software", MarketCap = 10000000000 },
                new Stock { Id = 111, Symbol = "ROKU", CompanyName = "Roku", Purchase = 75.20m, LastDiv = 0.00m, Industry = "Entertainment", MarketCap = 11000000000 },
                new Stock { Id = 112, Symbol = "PATH", CompanyName = "UiPath", Purchase = 13.40m, LastDiv = 0.00m, Industry = "Software", MarketCap = 7500000000 },
                new Stock { Id = 113, Symbol = "MDB", CompanyName = "MongoDB", Purchase = 280.90m, LastDiv = 0.00m, Industry = "Software", MarketCap = 20000000000 },
                new Stock { Id = 114, Symbol = "RBLX", CompanyName = "Roblox", Purchase = 42.10m, LastDiv = 0.00m, Industry = "Gaming", MarketCap = 26000000000 },
                new Stock { Id = 115, Symbol = "U", CompanyName = "Unity Software", Purchase = 18.50m, LastDiv = 0.00m, Industry = "Software", MarketCap = 7000000000 },
                new Stock { Id = 116, Symbol = "TTD", CompanyName = "The Trade Desk", Purchase = 102.30m, LastDiv = 0.00m, Industry = "Advertising", MarketCap = 50000000000 },
                new Stock { Id = 117, Symbol = "APP", CompanyName = "AppLovin", Purchase = 85.60m, LastDiv = 0.00m, Industry = "Software", MarketCap = 28000000000 },
                new Stock { Id = 118, Symbol = "AFRM", CompanyName = "Affirm Holdings", Purchase = 38.40m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 12000000000 },
                new Stock { Id = 119, Symbol = "SOFI", CompanyName = "SoFi Technologies", Purchase = 8.20m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 8800000000 },
                new Stock { Id = 120, Symbol = "HOOD", CompanyName = "Robinhood", Purchase = 22.40m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 19000000000 },
                new Stock { Id = 121, Symbol = "PINS", CompanyName = "Pinterest", Purchase = 31.50m, LastDiv = 0.00m, Industry = "Social Media", MarketCap = 21000000000 },
                new Stock { Id = 122, Symbol = "SNAP", CompanyName = "Snap Inc", Purchase = 9.80m, LastDiv = 0.00m, Industry = "Social Media", MarketCap = 16000000000 },
                new Stock { Id = 123, Symbol = "LYFT", CompanyName = "Lyft Inc", Purchase = 12.40m, LastDiv = 0.00m, Industry = "Transportation", MarketCap = 5000000000 },
                new Stock { Id = 124, Symbol = "DASH", CompanyName = "DoorDash", Purchase = 128.50m, LastDiv = 0.00m, Industry = "Services", MarketCap = 52000000000 },
                new Stock { Id = 125, Symbol = "ABNB", CompanyName = "Airbnb", Purchase = 118.20m, LastDiv = 0.00m, Industry = "Hospitality", MarketCap = 74000000000 },
                new Stock { Id = 126, Symbol = "ZM", CompanyName = "Zoom Video", Purchase = 68.30m, LastDiv = 0.00m, Industry = "Software", MarketCap = 21000000000 },
                new Stock { Id = 127, Symbol = "DOCU", CompanyName = "DocuSign", Purchase = 58.10m, LastDiv = 0.00m, Industry = "Software", MarketCap = 12000000000 },
                new Stock { Id = 128, Symbol = "OKTA", CompanyName = "Okta Inc", Purchase = 82.40m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 14000000000 },
                new Stock { Id = 129, Symbol = "ESTC", CompanyName = "Elastic NV", Purchase = 78.90m, LastDiv = 0.00m, Industry = "Software", MarketCap = 8200000000 },
                new Stock { Id = 130, Symbol = "GTLB", CompanyName = "GitLab", Purchase = 52.30m, LastDiv = 0.00m, Industry = "Software", MarketCap = 8400000000 },
                new Stock { Id = 131, Symbol = "ARM", CompanyName = "Arm Holdings", Purchase = 138.50m, LastDiv = 0.00m, Industry = "Semiconductors", MarketCap = 143000000000 },
                new Stock { Id = 132, Symbol = "SMCI", CompanyName = "Super Micro Computer", Purchase = 450.20m, LastDiv = 0.00m, Industry = "Hardware", MarketCap = 26000000000 },
                new Stock { Id = 133, Symbol = "ASTS", CompanyName = "AST Spacemobile", Purchase = 28.40m, LastDiv = 0.00m, Industry = "Telecommunications", MarketCap = 7200000000 },
                new Stock { Id = 134, Symbol = "RKLB", CompanyName = "Rocket Lab", Purchase = 6.80m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 3400000000 },
                new Stock { Id = 135, Symbol = "LUNR", CompanyName = "Intuitive Machines", Purchase = 5.20m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 750000000 },
                new Stock { Id = 136, Symbol = "JOBY", CompanyName = "Joby Aviation", Purchase = 5.10m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 3600000000 },
                new Stock { Id = 137, Symbol = "ACHR", CompanyName = "Archer Aviation", Purchase = 3.80m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 1200000000 },
                new Stock { Id = 138, Symbol = "IONQ", CompanyName = "IonQ Inc", Purchase = 8.10m, LastDiv = 0.00m, Industry = "Computing", MarketCap = 1700000000 },
                new Stock { Id = 139, Symbol = "RGTI", CompanyName = "Rigetti Computing", Purchase = 1.15m, LastDiv = 0.00m, Industry = "Computing", MarketCap = 220000000 },
                new Stock { Id = 140, Symbol = "SOUN", CompanyName = "SoundHound AI", Purchase = 5.30m, LastDiv = 0.00m, Industry = "Software", MarketCap = 1800000000 },
                new Stock { Id = 141, Symbol = "BBAI", CompanyName = "BigBear.ai", Purchase = 1.85m, LastDiv = 0.00m, Industry = "Software", MarketCap = 450000000 },
                new Stock { Id = 142, Symbol = "AI", CompanyName = "C3.ai", Purchase = 24.10m, LastDiv = 0.00m, Industry = "Software", MarketCap = 3000000000 },
                new Stock { Id = 143, Symbol = "S", CompanyName = "SentinelOne", Purchase = 22.80m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 7100000000 },
                new Stock { Id = 144, Symbol = "TENB", CompanyName = "Tenable Holdings", Purchase = 42.10m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 4900000000 },
                new Stock { Id = 145, Symbol = "VRNS", CompanyName = "Varonis Systems", Purchase = 54.30m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 6000000000 },
                new Stock { Id = 146, Symbol = "RPD", CompanyName = "Rapid7", Purchase = 38.20m, LastDiv = 0.00m, Industry = "Cybersecurity", MarketCap = 2400000000 },
                new Stock { Id = 147, Symbol = "BILL", CompanyName = "Bill Holdings", Purchase = 52.40m, LastDiv = 0.00m, Industry = "Fintech", MarketCap = 5400000000 },
                new Stock { Id = 148, Symbol = "TOST", CompanyName = "Toast Inc", Purchase = 26.80m, LastDiv = 0.00m, Industry = "Software", MarketCap = 14800000000 },
                new Stock { Id = 149, Symbol = "GRAB", CompanyName = "Grab Holdings", Purchase = 3.45m, LastDiv = 0.00m, Industry = "Transportation", MarketCap = 13500000000 },
                new Stock { Id = 150, Symbol = "SE", CompanyName = "Sea Limited", Purchase = 81.20m, LastDiv = 0.00m, Industry = "E-Commerce", MarketCap = 46000000000 },

                // 151–200
                new Stock { Id = 151, Symbol = "BAC", CompanyName = "Bank of America Corp", Purchase = 39.80m, LastDiv = 0.26m, Industry = "Financials", MarketCap = 310000000000 },
                new Stock { Id = 152, Symbol = "WFC", CompanyName = "Wells Fargo", Purchase = 56.30m, LastDiv = 0.35m, Industry = "Financials", MarketCap = 195000000000 },
                new Stock { Id = 153, Symbol = "C", CompanyName = "Citigroup", Purchase = 61.20m, LastDiv = 0.53m, Industry = "Financials", MarketCap = 116000000000 },
                new Stock { Id = 154, Symbol = "MS", CompanyName = "Morgan Stanley", Purchase = 98.40m, LastDiv = 0.85m, Industry = "Financials", MarketCap = 160000000000 },
                new Stock { Id = 155, Symbol = "USB", CompanyName = "US Bancorp", Purchase = 44.10m, LastDiv = 0.49m, Industry = "Financials", MarketCap = 68000000000 },
                new Stock { Id = 156, Symbol = "PNC", CompanyName = "PNC Financial", Purchase = 165.20m, LastDiv = 1.55m, Industry = "Financials", MarketCap = 65000000000 },
                new Stock { Id = 157, Symbol = "TFC", CompanyName = "Truist Financial", Purchase = 42.80m, LastDiv = 0.52m, Industry = "Financials", MarketCap = 57000000000 },
                new Stock { Id = 158, Symbol = "BK", CompanyName = "BNY Mellon", Purchase = 64.30m, LastDiv = 0.42m, Industry = "Financials", MarketCap = 48000000000 },
                new Stock { Id = 159, Symbol = "STT", CompanyName = "State Street", Purchase = 84.10m, LastDiv = 0.69m, Industry = "Financials", MarketCap = 25000000000 },
                new Stock { Id = 160, Symbol = "FITB", CompanyName = "Fifth Third Bancorp", Purchase = 38.50m, LastDiv = 0.35m, Industry = "Financials", MarketCap = 26000000000 },
                new Stock { Id = 161, Symbol = "KEY", CompanyName = "KeyCorp", Purchase = 15.80m, LastDiv = 0.20m, Industry = "Financials", MarketCap = 15000000000 },
                new Stock { Id = 162, Symbol = "CFG", CompanyName = "Citizens Financial", Purchase = 36.20m, LastDiv = 0.42m, Industry = "Financials", MarketCap = 17000000000 },
                new Stock { Id = 163, Symbol = "RF", CompanyName = "Regions Financial", Purchase = 21.40m, LastDiv = 0.24m, Industry = "Financials", MarketCap = 19000000000 },
                new Stock { Id = 164, Symbol = "HBAN", CompanyName = "Huntington Bancshares", Purchase = 14.60m, LastDiv = 0.15m, Industry = "Financials", MarketCap = 21000000000 },
                new Stock { Id = 165, Symbol = "AIG", CompanyName = "American International", Purchase = 74.20m, LastDiv = 0.36m, Industry = "Insurance", MarketCap = 49000000000 },
                new Stock { Id = 166, Symbol = "MET", CompanyName = "MetLife", Purchase = 72.80m, LastDiv = 0.52m, Industry = "Insurance", MarketCap = 52000000000 },
                new Stock { Id = 167, Symbol = "PRU", CompanyName = "Prudential Financial", Purchase = 118.50m, LastDiv = 1.30m, Industry = "Insurance", MarketCap = 43000000000 },
                new Stock { Id = 168, Symbol = "ALL", CompanyName = "Allstate", Purchase = 182.40m, LastDiv = 0.92m, Industry = "Insurance", MarketCap = 48000000000 },
                new Stock { Id = 169, Symbol = "TRV", CompanyName = "The Travelers Companies", Purchase = 230.10m, LastDiv = 1.05m, Industry = "Insurance", MarketCap = 52000000000 },
                new Stock { Id = 170, Symbol = "HIG", CompanyName = "The Hartford", Purchase = 105.30m, LastDiv = 0.47m, Industry = "Insurance", MarketCap = 31000000000 },
                new Stock { Id = 171, Symbol = "AFL", CompanyName = "Aflac", Purchase = 92.40m, LastDiv = 0.50m, Industry = "Insurance", MarketCap = 53000000000 },
                new Stock { Id = 172, Symbol = "AMP", CompanyName = "Ameriprise Financial", Purchase = 440.80m, LastDiv = 1.48m, Industry = "Financials", MarketCap = 43000000000 },
                new Stock { Id = 173, Symbol = "RJF", CompanyName = "Raymond James", Purchase = 122.50m, LastDiv = 0.45m, Industry = "Financials", MarketCap = 25000000000 },
                new Stock { Id = 174, Symbol = "MSCI", CompanyName = "MSCI Inc", Purchase = 560.20m, LastDiv = 1.60m, Industry = "Financials", MarketCap = 44000000000 },
                new Stock { Id = 175, Symbol = "CBOE", CompanyName = "Cboe Global Markets", Purchase = 205.40m, LastDiv = 0.55m, Industry = "Financials", MarketCap = 21000000000 },
                new Stock { Id = 176, Symbol = "CME", CompanyName = "CME Group", Purchase = 218.90m, LastDiv = 1.15m, Industry = "Financials", MarketCap = 78000000000 },
                new Stock { Id = 177, Symbol = "ICE", CompanyName = "Intercontinental Exchange", Purchase = 155.30m, LastDiv = 0.45m, Industry = "Financials", MarketCap = 89000000000 },
                new Stock { Id = 178, Symbol = "NDAQ", CompanyName = "Nasdaq Inc", Purchase = 68.20m, LastDiv = 0.24m, Industry = "Financials", MarketCap = 39000000000 },
                new Stock { Id = 179, Symbol = "AON", CompanyName = "Aon plc", Purchase = 340.50m, LastDiv = 0.67m, Industry = "Insurance", MarketCap = 74000000000 },
                new Stock { Id = 180, Symbol = "WTW", CompanyName = "Willis Towers Watson", Purchase = 285.10m, LastDiv = 0.88m, Industry = "Insurance", MarketCap = 28000000000 },
                new Stock { Id = 181, Symbol = "T", CompanyName = "AT&T", Purchase = 19.40m, LastDiv = 0.27m, Industry = "Telecommunications", MarketCap = 139000000000 },
                new Stock { Id = 182, Symbol = "VZ", CompanyName = "Verizon", Purchase = 41.80m, LastDiv = 0.66m, Industry = "Telecommunications", MarketCap = 175000000000 },
                new Stock { Id = 183, Symbol = "TMUS", CompanyName = "T-Mobile US", Purchase = 195.20m, LastDiv = 0.65m, Industry = "Telecommunications", MarketCap = 228000000000 },
                new Stock { Id = 184, Symbol = "CMCSA", CompanyName = "Comcast", Purchase = 39.50m, LastDiv = 0.31m, Industry = "Entertainment", MarketCap = 153000000000 },
                new Stock { Id = 185, Symbol = "CHTR", CompanyName = "Charter Communications", Purchase = 320.40m, LastDiv = 0.00m, Industry = "Telecommunications", MarketCap = 46000000000 },
                new Stock { Id = 186, Symbol = "LNT", CompanyName = "Alliant Energy", Purchase = 58.20m, LastDiv = 0.48m, Industry = "Utilities", MarketCap = 14000000000 },
                new Stock { Id = 187, Symbol = "AEP", CompanyName = "American Electric Power", Purchase = 98.10m, LastDiv = 0.88m, Industry = "Utilities", MarketCap = 51000000000 },
                new Stock { Id = 188, Symbol = "D", CompanyName = "Dominion Energy", Purchase = 56.40m, LastDiv = 0.66m, Industry = "Utilities", MarketCap = 47000000000 },
                new Stock { Id = 189, Symbol = "DUK", CompanyName = "Duke Energy", Purchase = 112.30m, LastDiv = 1.02m, Industry = "Utilities", MarketCap = 86000000000 },
                new Stock { Id = 190, Symbol = "SO", CompanyName = "The Southern Company", Purchase = 88.50m, LastDiv = 0.72m, Industry = "Utilities", MarketCap = 96000000000 },
                new Stock { Id = 191, Symbol = "NEE", CompanyName = "NextEra Energy", Purchase = 81.40m, LastDiv = 0.51m, Industry = "Utilities", MarketCap = 167000000000 },
                new Stock { Id = 192, Symbol = "EXC", CompanyName = "Exelon", Purchase = 39.80m, LastDiv = 0.38m, Industry = "Utilities", MarketCap = 39000000000 },
                new Stock { Id = 193, Symbol = "XEL", CompanyName = "Xcel Energy", Purchase = 64.20m, LastDiv = 0.54m, Industry = "Utilities", MarketCap = 35000000000 },
                new Stock { Id = 194, Symbol = "ED", CompanyName = "Consolidated Edison", Purchase = 98.60m, LastDiv = 0.83m, Industry = "Utilities", MarketCap = 34000000000 },
                new Stock { Id = 195, Symbol = "WEC", CompanyName = "WEC Energy Group", Purchase = 89.10m, LastDiv = 0.83m, Industry = "Utilities", MarketCap = 28000000000 },
                new Stock { Id = 196, Symbol = "EIX", CompanyName = "Edison International", Purchase = 84.50m, LastDiv = 0.78m, Industry = "Utilities", MarketCap = 32000000000 },
                new Stock { Id = 197, Symbol = "AWK", CompanyName = "American Water Works", Purchase = 138.20m, LastDiv = 0.76m, Industry = "Utilities", MarketCap = 27000000000 },
                new Stock { Id = 198, Symbol = "AEE", CompanyName = "Ameren", Purchase = 82.40m, LastDiv = 0.67m, Industry = "Utilities", MarketCap = 21000000000 },
                new Stock { Id = 199, Symbol = "CMS", CompanyName = "CMS Energy", Purchase = 68.90m, LastDiv = 0.51m, Industry = "Utilities", MarketCap = 20000000000 },
                new Stock { Id = 200, Symbol = "DTE", CompanyName = "DTE Energy", Purchase = 125.10m, LastDiv = 1.02m, Industry = "Utilities", MarketCap = 25000000000 },

                // 201–250
                new Stock { Id = 201, Symbol = "SLB", CompanyName = "Schlumberger", Purchase = 45.20m, LastDiv = 0.27m, Industry = "Energy", MarketCap = 64000000000 },
                new Stock { Id = 202, Symbol = "HAL", CompanyName = "Halliburton", Purchase = 32.10m, LastDiv = 0.17m, Industry = "Energy", MarketCap = 28000000000 },
                new Stock { Id = 203, Symbol = "BKR", CompanyName = "Baker Hughes", Purchase = 35.80m, LastDiv = 0.21m, Industry = "Energy", MarketCap = 35000000000 },
                new Stock { Id = 204, Symbol = "EOG", CompanyName = "EOG Resources", Purchase = 125.40m, LastDiv = 0.91m, Industry = "Energy", MarketCap = 72000000000 },
                new Stock { Id = 205, Symbol = "COP", CompanyName = "ConocoPhillips", Purchase = 112.80m, LastDiv = 0.58m, Industry = "Energy", MarketCap = 131000000000 },
                new Stock { Id = 206, Symbol = "PXD", CompanyName = "Pioneer Natural Resources", Purchase = 268.00m, LastDiv = 1.10m, Industry = "Energy", MarketCap = 62000000000 },
                new Stock { Id = 207, Symbol = "OXY", CompanyName = "Occidental Petroleum", Purchase = 56.30m, LastDiv = 0.22m, Industry = "Energy", MarketCap = 50000000000 },
                new Stock { Id = 208, Symbol = "MPC", CompanyName = "Marathon Petroleum", Purchase = 172.50m, LastDiv = 0.82m, Industry = "Energy", MarketCap = 59000000000 },
                new Stock { Id = 209, Symbol = "VLO", CompanyName = "Valero Energy", Purchase = 148.90m, LastDiv = 1.07m, Industry = "Energy", MarketCap = 48000000000 },
                new Stock { Id = 210, Symbol = "PSX", CompanyName = "Phillips 66", Purchase = 138.20m, LastDiv = 1.15m, Industry = "Energy", MarketCap = 58000000000 },
                new Stock { Id = 211, Symbol = "HES", CompanyName = "Hess Corporation", Purchase = 142.10m, LastDiv = 0.43m, Industry = "Energy", MarketCap = 43000000000 },
                new Stock { Id = 212, Symbol = "DVN", CompanyName = "Devon Energy", Purchase = 41.50m, LastDiv = 0.35m, Industry = "Energy", MarketCap = 26000000000 },
                new Stock { Id = 213, Symbol = "FANG", CompanyName = "Diamondback Energy", Purchase = 185.30m, LastDiv = 0.90m, Industry = "Energy", MarketCap = 33000000000 },
                new Stock { Id = 214, Symbol = "KMI", CompanyName = "Kinder Morgan", Purchase = 21.80m, LastDiv = 0.28m, Industry = "Energy", MarketCap = 48000000000 },
                new Stock { Id = 215, Symbol = "WMB", CompanyName = "Williams Companies", Purchase = 44.20m, LastDiv = 0.47m, Industry = "Energy", MarketCap = 53000000000 },
                new Stock { Id = 216, Symbol = "OKE", CompanyName = "ONEOK", Purchase = 88.50m, LastDiv = 0.99m, Industry = "Energy", MarketCap = 51000000000 },
                new Stock { Id = 217, Symbol = "TRGP", CompanyName = "Targa Resources", Purchase = 135.10m, LastDiv = 0.75m, Industry = "Energy", MarketCap = 30000000000 },
                new Stock { Id = 218, Symbol = "FCX", CompanyName = "Freeport-McMoRan", Purchase = 48.20m, LastDiv = 0.15m, Industry = "Materials", MarketCap = 69000000000 },
                new Stock { Id = 219, Symbol = "NEM", CompanyName = "Newmont Corporation", Purchase = 48.90m, LastDiv = 0.25m, Industry = "Materials", MarketCap = 56000000000 },
                new Stock { Id = 220, Symbol = "SCCO", CompanyName = "Southern Copper", Purchase = 108.50m, LastDiv = 0.80m, Industry = "Materials", MarketCap = 83000000000 },
                new Stock { Id = 221, Symbol = "LIN", CompanyName = "Linde plc", Purchase = 465.30m, LastDiv = 1.39m, Industry = "Chemicals", MarketCap = 222000000000 },
                new Stock { Id = 222, Symbol = "APD", CompanyName = "Air Products", Purchase = 285.40m, LastDiv = 1.77m, Industry = "Chemicals", MarketCap = 63000000000 },
                new Stock { Id = 223, Symbol = "DD", CompanyName = "DuPont de Nemours", Purchase = 82.10m, LastDiv = 0.38m, Industry = "Chemicals", MarketCap = 34000000000 },
                new Stock { Id = 224, Symbol = "DOW", CompanyName = "Dow Inc", Purchase = 52.30m, LastDiv = 0.70m, Industry = "Chemicals", MarketCap = 36000000000 },
                new Stock { Id = 225, Symbol = "PPG", CompanyName = "PPG Industries", Purchase = 132.80m, LastDiv = 0.68m, Industry = "Chemicals", MarketCap = 31000000000 },
                new Stock { Id = 226, Symbol = "ALB", CompanyName = "Albemarle", Purchase = 92.50m, LastDiv = 0.40m, Industry = "Chemicals", MarketCap = 10800000000 },
                new Stock { Id = 227, Symbol = "NUE", CompanyName = "Nucor Corporation", Purchase = 158.40m, LastDiv = 0.54m, Industry = "Materials", MarketCap = 37000000000 },
                new Stock { Id = 228, Symbol = "STLD", CompanyName = "Steel Dynamics", Purchase = 125.10m, LastDiv = 0.46m, Industry = "Materials", MarketCap = 19000000000 },
                new Stock { Id = 229, Symbol = "VMC", CompanyName = "Vulcan Materials", Purchase = 255.80m, LastDiv = 0.46m, Industry = "Materials", MarketCap = 33000000000 },
                new Stock { Id = 230, Symbol = "MLM", CompanyName = "Martin Marietta", Purchase = 580.20m, LastDiv = 0.74m, Industry = "Materials", MarketCap = 35000000000 },
                new Stock { Id = 231, Symbol = "HON", CompanyName = "Honeywell", Purchase = 205.30m, LastDiv = 1.08m, Industry = "Industrials", MarketCap = 133000000000 },
                new Stock { Id = 232, Symbol = "GE", CompanyName = "General Electric", Purchase = 172.40m, LastDiv = 0.28m, Industry = "Industrials", MarketCap = 188000000000 },
                new Stock { Id = 233, Symbol = "MMM", CompanyName = "3M Company", Purchase = 128.50m, LastDiv = 0.70m, Industry = "Industrials", MarketCap = 70000000000 },
                new Stock { Id = 234, Symbol = "RTX", CompanyName = "RTX Corporation", Purchase = 120.10m, LastDiv = 0.63m, Industry = "Aerospace", MarketCap = 159000000000 },
                new Stock { Id = 235, Symbol = "LMT", CompanyName = "Lockheed Martin", Purchase = 560.40m, LastDiv = 3.15m, Industry = "Aerospace", MarketCap = 134000000000 },
                new Stock { Id = 236, Symbol = "BA", CompanyName = "Boeing", Purchase = 162.30m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 99000000000 },
                new Stock { Id = 237, Symbol = "NOC", CompanyName = "Northrop Grumman", Purchase = 520.80m, LastDiv = 2.06m, Industry = "Aerospace", MarketCap = 76000000000 },
                new Stock { Id = 238, Symbol = "GD", CompanyName = "General Dynamics", Purchase = 302.50m, LastDiv = 1.42m, Industry = "Aerospace", MarketCap = 82000000000 },
                new Stock { Id = 239, Symbol = "TDG", CompanyName = "TransDigm Group", Purchase = 1320.00m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 74000000000 },
                new Stock { Id = 240, Symbol = "AXON", CompanyName = "Axon Enterprise", Purchase = 380.50m, LastDiv = 0.00m, Industry = "Aerospace", MarketCap = 28000000000 },
                new Stock { Id = 241, Symbol = "EMR", CompanyName = "Emerson Electric", Purchase = 108.20m, LastDiv = 0.52m, Industry = "Industrials", MarketCap = 62000000000 },
                new Stock { Id = 242, Symbol = "ROK", CompanyName = "Rockwell Automation", Purchase = 275.40m, LastDiv = 1.25m, Industry = "Industrials", MarketCap = 31000000000 },
                new Stock { Id = 243, Symbol = "AME", CompanyName = "AMETEK", Purchase = 172.10m, LastDiv = 0.28m, Industry = "Industrials", MarketCap = 39000000000 },
                new Stock { Id = 244, Symbol = "TT", CompanyName = "Trane Technologies", Purchase = 380.20m, LastDiv = 0.84m, Industry = "Industrials", MarketCap = 85000000000 },
                new Stock { Id = 245, Symbol = "CARR", CompanyName = "Carrier Global", Purchase = 68.50m, LastDiv = 0.19m, Industry = "Industrials", MarketCap = 61000000000 },
                new Stock { Id = 246, Symbol = "OTIS", CompanyName = "Otis Worldwide", Purchase = 98.20m, LastDiv = 0.39m, Industry = "Industrials", MarketCap = 39000000000 },
                new Stock { Id = 247, Symbol = "FAST", CompanyName = "Fastenal", Purchase = 70.40m, LastDiv = 0.39m, Industry = "Industrials", MarketCap = 40000000000 },
                new Stock { Id = 248, Symbol = "GWW", CompanyName = "WW Grainger", Purchase = 980.50m, LastDiv = 2.05m, Industry = "Industrials", MarketCap = 48000000000 },
                new Stock { Id = 249, Symbol = "CP", CompanyName = "Canadian Pacific Kansas", Purchase = 82.30m, LastDiv = 0.19m, Industry = "Transportation", MarketCap = 76000000000 },
                new Stock { Id = 250, Symbol = "CNI", CompanyName = "Canadian National Railway", Purchase = 118.50m, LastDiv = 0.84m, Industry = "Transportation", MarketCap = 74000000000 },
                new Stock { Id = 251, Symbol = "SPY", CompanyName = "SPDR S&P 500 ETF", Purchase = 560.20m, LastDiv = 1.85m, Industry = "ETF", MarketCap = 560000000000 },
                new Stock { Id = 252, Symbol = "QQQ", CompanyName = "Invesco QQQ Trust", Purchase = 480.50m, LastDiv = 0.68m, Industry = "ETF", MarketCap = 280000000000 },
                new Stock { Id = 253, Symbol = "VOO", CompanyName = "Vanguard S&P 500 ETF", Purchase = 515.30m, LastDiv = 1.70m, Industry = "ETF", MarketCap = 480000000000 },
                new Stock { Id = 254, Symbol = "VTI", CompanyName = "Vanguard Total Stock ETF", Purchase = 272.80m, LastDiv = 0.92m, Industry = "ETF", MarketCap = 390000000000 },
                new Stock { Id = 255, Symbol = "IWM", CompanyName = "iShares Russell 2000 ETF", Purchase = 218.40m, LastDiv = 0.72m, Industry = "ETF", MarketCap = 68000000008 },
                new Stock { Id = 256, Symbol = "SCHD", CompanyName = "Schwab US Dividend Equity", Purchase = 82.50m, LastDiv = 0.75m, Industry = "ETF", MarketCap = 58000000000 },
                new Stock { Id = 257, Symbol = "JEPI", CompanyName = "JPMorgan Equity Premium", Purchase = 58.20m, LastDiv = 0.38m, Industry = "ETF", MarketCap = 34000000000 },
                new Stock { Id = 258, Symbol = "JEPQ", CompanyName = "JPMorgan Nasdaq Equity", Purchase = 54.10m, LastDiv = 0.42m, Industry = "ETF", MarketCap = 18000000000 },
                new Stock { Id = 259, Symbol = "SMH", CompanyName = "VanEck Semiconductor ETF", Purchase = 245.80m, LastDiv = 0.45m, Industry = "ETF", MarketCap = 24000000000 },
                new Stock { Id = 260, Symbol = "XLE", CompanyName = "Energy Select Sector SPDR", Purchase = 88.20m, LastDiv = 0.82m, Industry = "ETF", MarketCap = 38000000000 },
                new Stock { Id = 261, Symbol = "XLF", CompanyName = "Financial Select Sector SPDR", Purchase = 44.50m, LastDiv = 0.22m, Industry = "ETF", MarketCap = 42000000000 },
                new Stock { Id = 262, Symbol = "XLK", CompanyName = "Technology Select Sector", Purchase = 225.10m, LastDiv = 0.48m, Industry = "ETF", MarketCap = 72000000000 },
                new Stock { Id = 263, Symbol = "XLV", CompanyName = "Health Care Select SPDR", Purchase = 148.90m, LastDiv = 0.58m, Industry = "ETF", MarketCap = 40000000000 },
                new Stock { Id = 264, Symbol = "XLY", CompanyName = "Consumer Discretionary SPDR", Purchase = 185.30m, LastDiv = 0.45m, Industry = "ETF", MarketCap = 22000000000 },
                new Stock { Id = 265, Symbol = "XLP", CompanyName = "Consumer Staples SPDR", Purchase = 78.40m, LastDiv = 0.52m, Industry = "ETF", MarketCap = 17000000000 },
                new Stock { Id = 266, Symbol = "XLI", CompanyName = "Industrial Select Sector", Purchase = 128.50m, LastDiv = 0.48m, Industry = "ETF", MarketCap = 21000000000 },
                new Stock { Id = 267, Symbol = "XLU", CompanyName = "Utilities Select Sector", Purchase = 72.10m, LastDiv = 0.58m, Industry = "ETF", MarketCap = 16000000000 },
                new Stock { Id = 268, Symbol = "XLB", CompanyName = "Materials Select Sector", Purchase = 89.40m, LastDiv = 0.42m, Industry = "ETF", MarketCap = 6200000000 },
                new Stock { Id = 269, Symbol = "VNQ", CompanyName = "Vanguard Real Estate ETF", Purchase = 88.50m, LastDiv = 0.82m, Industry = "Real Estate", MarketCap = 33000000000 },
                new Stock { Id = 270, Symbol = "PLD", CompanyName = "Prologis Inc", Purchase = 122.40m, LastDiv = 0.96m, Industry = "Real Estate", MarketCap = 113000000000 },
                new Stock { Id = 271, Symbol = "AMT", CompanyName = "American Tower", Purchase = 225.80m, LastDiv = 1.62m, Industry = "Real Estate", MarketCap = 105000000000 },
                new Stock { Id = 272, Symbol = "EQIX", CompanyName = "Equinix Inc", Purchase = 880.50m, LastDiv = 4.26m, Industry = "Real Estate", MarketCap = 84000000000 },
                new Stock { Id = 273, Symbol = "O", CompanyName = "Realty Income", Purchase = 62.40m, LastDiv = 0.26m, Industry = "Real Estate", MarketCap = 54000000000 },
                new Stock { Id = 274, Symbol = "WELL", CompanyName = "Welltower Inc", Purchase = 118.20m, LastDiv = 0.67m, Industry = "Real Estate", MarketCap = 71000000000 },
                new Stock { Id = 275, Symbol = "SPG", CompanyName = "Simon Property Group", Purchase = 165.40m, LastDiv = 2.00m, Industry = "Real Estate", MarketCap = 54000000000 },
                new Stock { Id = 276, Symbol = "PSA", CompanyName = "Public Storage", Purchase = 325.10m, LastDiv = 3.00m, Industry = "Real Estate", MarketCap = 57000000000 },
                new Stock { Id = 277, Symbol = "DLR", CompanyName = "Digital Realty Trust", Purchase = 158.90m, LastDiv = 1.22m, Industry = "Real Estate", MarketCap = 50000000000 },
                new Stock { Id = 278, Symbol = "VICI", CompanyName = "VICI Properties", Purchase = 32.50m, LastDiv = 0.41m, Industry = "Real Estate", MarketCap = 34000000000 },
                new Stock { Id = 279, Symbol = "CBRE", CompanyName = "CBRE Group", Purchase = 115.20m, LastDiv = 0.00m, Industry = "Real Estate", MarketCap = 35000000000 },
                new Stock { Id = 280, Symbol = "WY", CompanyName = "Weyerhaeuser Co", Purchase = 31.80m, LastDiv = 0.20m, Industry = "Real Estate", MarketCap = 23000000000 },
                new Stock { Id = 281, Symbol = "AVB", CompanyName = "AvalonBay Communities", Purchase = 215.40m, LastDiv = 1.70m, Industry = "Real Estate", MarketCap = 30000000000 },
                new Stock { Id = 282, Symbol = "EQR", CompanyName = "Equity Residential", Purchase = 72.80m, LastDiv = 0.67m, Industry = "Real Estate", MarketCap = 27000000000 },
                new Stock { Id = 283, Symbol = "SBAC", CompanyName = "SBA Communications", Purchase = 235.10m, LastDiv = 0.98m, Industry = "Real Estate", MarketCap = 25000000000 },
                new Stock { Id = 284, Symbol = "INVH", CompanyName = "Invitation Homes", Purchase = 35.20m, LastDiv = 0.28m, Industry = "Real Estate", MarketCap = 21000000000 },
                new Stock { Id = 285, Symbol = "ARE", CompanyName = "Alexandria Real Estate", Purchase = 122.50m, LastDiv = 1.27m, Industry = "Real Estate", MarketCap = 21000000000 },
                new Stock { Id = 286, Symbol = "MAA", CompanyName = "Mid-America Apartment", Purchase = 158.40m, LastDiv = 1.47m, Industry = "Real Estate", MarketCap = 18000000000 },
                new Stock { Id = 287, Symbol = "ESS", CompanyName = "Essex Property Trust", Purchase = 295.10m, LastDiv = 2.45m, Industry = "Real Estate", MarketCap = 19000000000 },
                new Stock { Id = 288, Symbol = "UDR", CompanyName = "UDR Inc", Purchase = 44.20m, LastDiv = 0.42m, Industry = "Real Estate", MarketCap = 14000000000 },
                new Stock { Id = 289, Symbol = "HST", CompanyName = "Host Hotels & Resorts", Purchase = 18.50m, LastDiv = 0.20m, Industry = "Real Estate", MarketCap = 13000000000 },
                new Stock { Id = 290, Symbol = "CPT", CompanyName = "Camden Property Trust", Purchase = 120.80m, LastDiv = 1.03m, Industry = "Real Estate", MarketCap = 13000000000 },
                new Stock { Id = 291, Symbol = "KIM", CompanyName = "Kimco Realty", Purchase = 22.40m, LastDiv = 0.24m, Industry = "Real Estate", MarketCap = 15000000000 },
                new Stock { Id = 292, Symbol = "BXP", CompanyName = "Boston Properties", Purchase = 78.50m, LastDiv = 0.98m, Industry = "Real Estate", MarketCap = 12000000000 },
                new Stock { Id = 293, Symbol = "REG", CompanyName = "Regency Centers", Purchase = 71.20m, LastDiv = 0.67m, Industry = "Real Estate", MarketCap = 13000000000 },
                new Stock { Id = 294, Symbol = "FRT", CompanyName = "Federal Realty Investment", Purchase = 112.40m, LastDiv = 1.09m, Industry = "Real Estate", MarketCap = 9500000000 },
                new Stock { Id = 295, Symbol = "NNN", CompanyName = "NNN REIT Inc", Purchase = 48.20m, LastDiv = 0.58m, Industry = "Real Estate", MarketCap = 8800000000 },
                new Stock { Id = 296, Symbol = "ADC", CompanyName = "Agree Realty", Purchase = 74.50m, LastDiv = 0.25m, Industry = "Real Estate", MarketCap = 7500000000 },
                new Stock { Id = 297, Symbol = "STAG", CompanyName = "STAG Industrial", Purchase = 38.90m, LastDiv = 0.12m, Industry = "Real Estate", MarketCap = 7100000000 },
                new Stock { Id = 298, Symbol = "EPR", CompanyName = "EPR Properties", Purchase = 48.10m, LastDiv = 0.28m, Industry = "Real Estate", MarketCap = 3600000000 },
                new Stock { Id = 299, Symbol = "OHI", CompanyName = "Omega Healthcare Investors", Purchase = 38.40m, LastDiv = 0.67m, Industry = "Real Estate", MarketCap = 9800000000 },
                new Stock { Id = 300, Symbol = "MPW", CompanyName = "Medical Properties Trust", Purchase = 5.20m, LastDiv = 0.15m, Industry = "Real Estate", MarketCap = 3100000000 }
                );


            modelBuilder.Entity<Comment>().HasIndex(c => new{c.StockId, c.CreatedOn });

            modelBuilder.Entity<Comment>().HasData(
// NVDA - 4 comments
new Comment { Id = 1, Title = "Strong Buy", Content = "Blackwell GPU demand is insane, this stock has legs.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 1, AppUserId = null },
new Comment { Id = 2, Title = "Long-term Hold", Content = "AI infrastructure spending keeps benefiting Nvidia. Not selling.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 1, AppUserId = null },
new Comment { Id = 3, Title = "Overvalued?", Content = "P/E is getting stretched. I trimmed my position last week.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 1, AppUserId = null },
new Comment { Id = 4, Title = "Dip Buyer", Content = "Every pullback on NVDA has been a buying opportunity so far.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 1, AppUserId = null },

// AAPL - 2 comments
new Comment { Id = 5, Title = "Cautious", Content = "Services revenue is great but hardware growth is slowing.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 2, AppUserId = null },
new Comment { Id = 6, Title = "Bullish on AI", Content = "Apple Intelligence could be a huge catalyst in 2025.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 2, AppUserId = null },
// GOOGL - 1 comment
new Comment { Id = 7, Title = "Ad Revenue Concern", Content = "AI search could cannibalize their core business long-term.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 3, AppUserId = null },

// MSFT - 3 comments
new Comment { Id = 8, Title = "AI Leader", Content = "Copilot integration across Office 365 is a massive moat.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 4, AppUserId = null },
new Comment { Id = 9, Title = "Azure Growth", Content = "Azure growth numbers keep impressing every quarter.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 4, AppUserId = null },
new Comment { Id = 10, Title = "Solid Dividend", Content = "Not flashy but MSFT keeps quietly raising its dividend.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 4, AppUserId = null },

// AMZN - 2 comments
new Comment { Id = 11, Title = "AWS Dominance", Content = "AWS margins are expanding nicely. Best cloud play out there.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 5, AppUserId = null },
new Comment { Id = 12, Title = "Retail Efficiency", Content = "Cost-cutting in logistics is finally showing up in earnings.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 5, AppUserId = null },         
// TSM - 4 comments
new Comment { Id = 13, Title = "Essential Monopoly", Content = "Every advanced chip runs through TSMC. Truly irreplaceable.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 6, AppUserId = null },
new Comment { Id = 14, Title = "Geopolitical Risk", Content = "Taiwan tensions are a real risk factor to keep watching.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 6, AppUserId = null },
new Comment { Id = 15, Title = "Arizona Expansion", Content = "US fab expansion reduces geopolitical risk over time.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 6, AppUserId = null },
new Comment { Id = 16, Title = "Pricing Power", Content = "TSMC keeps raising wafer prices and customers just pay it.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 6, AppUserId = null },

// AVGO - 1 comment
new Comment { Id = 17, Title = "Custom AI Chips", Content = "AVGO's custom ASIC business for hyperscalers is quietly booming.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 7, AppUserId = null },

// META - 3 comments
new Comment { Id = 18, Title = "Ad Machine", Content = "Their ad targeting is best-in-class and only getting stronger.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 8, AppUserId = null },
new Comment { Id = 19, Title = "Reality Labs Drain", Content = "Metaverse spending is still a massive cash burn with no end in sight.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 8, AppUserId = null },
new Comment { Id = 20, Title = "Llama Strategy", Content = "Open-sourcing Llama is a smart long-term moat-building play.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 8, AppUserId = null },

// TSLA - 2 comments
new Comment { Id = 21, Title = "Valuation Stretched", Content = "Hard to justify this price on auto earnings alone.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 9, AppUserId = null },
new Comment { Id = 22, Title = "FSD Potential", Content = "Full Self-Driving could completely re-rate this stock if it works.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 9, AppUserId = null },
// BRK-B - 1 comment
new Comment { Id = 23, Title = "Safe Haven", Content = "Buffett's cash pile gives him incredible flexibility right now.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 10, AppUserId = null },

// WMT - 2 comments
new Comment { Id = 24, Title = "Retail Powerhouse", Content = "Walmart's grocery dominance is extremely hard to compete with.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 11, AppUserId = null },
new Comment { Id = 25, Title = "E-Commerce Pivot", Content = "Walmart+ and online growth are finally clicking into place.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 11, AppUserId = null },

// LLY - 4 comments
new Comment { Id = 26, Title = "GLP-1 Leader", Content = "Mounjaro and Zepbound demand far outpaces supply right now.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 12, AppUserId = null },
new Comment { Id = 27, Title = "High Valuation", Content = "The premium is massive but the pipeline arguably justifies it.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 12, AppUserId = null },
new Comment { Id = 28, Title = "Supply Ramp", Content = "Manufacturing capacity is the only thing limiting LLY growth.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 12, AppUserId = null },
new Comment { Id = 29, Title = "Obesity Market", Content = "The total addressable market for obesity drugs is enormous.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc) , StockId = 12, AppUserId = null },

// JPM - 3 comments
new Comment { Id = 30, Title = "Best Bank", Content = "Dimon keeps executing flawlessly in any rate environment.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 13, AppUserId = null },
new Comment { Id = 31, Title = "Rate Sensitivity", Content = "NII may compress if the Fed cuts rates faster than expected.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 13, AppUserId = null },
new Comment { Id = 32, Title = "Fortress Balance Sheet", Content = "JPM always seems to come out of downturns stronger than peers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 13, AppUserId = null },

// V - 1 comment
new Comment { Id = 33, Title = "Cash Flow Beast", Content = "Visa's margins and free cash flow are simply phenomenal.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 14, AppUserId = null },

// XOM - 2 comments
new Comment { Id = 34, Title = "Dividend Rock", Content = "XOM's dividend history is about as reliable as it gets.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 15, AppUserId = null },
new Comment { Id = 35, Title = "Pioneer Synergies", Content = "Pioneer acquisition is boosting Permian production nicely.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 15, AppUserId = null },
// ASML - 4 comments
new Comment { Id = 36, Title = "EUV Monopoly", Content = "ASML is literally the only company making EUV lithography machines.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 16, AppUserId = null },
new Comment { Id = 37, Title = "China Export Risk", Content = "Export restrictions to China are a real headwind worth watching.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 16, AppUserId = null },
new Comment { Id = 38, Title = "High NA EUV", Content = "Next-gen High NA EUV tools will keep ASML ahead for a decade.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 16, AppUserId = null },
new Comment { Id = 39, Title = "Backlog Monster", Content = "The order backlog is enormous — revenue visibility is exceptional.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 16, AppUserId = null },

// TCEHY - 1 comment
new Comment { Id = 40, Title = "Regulatory Overhang", Content = "Chinese tech regulation remains an unpredictable ongoing concern.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 17, AppUserId = null },

// JNJ - 2 comments
new Comment { Id = 41, Title = "Defensive Pick", Content = "JNJ is a classic defensive hold with steady reliable dividends.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 18, AppUserId = null },
new Comment { Id = 42, Title = "MedTech Focus", Content = "Post-Kenvue spinoff JNJ is sharper and more focused than ever.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 18, AppUserId = null },
// MA - 3 comments
new Comment { Id = 43, Title = "Global Expansion", Content = "Mastercard benefits every single time a new market goes cashless.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 19, AppUserId = null },
new Comment { Id = 44, Title = "Cross-border Revenue", Content = "Travel recovery has been a huge tailwind for Mastercard.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 19, AppUserId = null },
new Comment { Id = 45, Title = "Crypto Hedge", Content = "MA is positioning itself well even in a crypto payments world.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 19, AppUserId = null },
// COST - 1 comment
new Comment { Id = 46, Title = "Membership Model", Content = "The 90%+ membership renewal rate is one of retail's best moats.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 20, AppUserId = null },

// NFLX - 2 comments
new Comment { Id = 47, Title = "Password Crackdown Win", Content = "Paid sharing drove subscriber growth well beyond expectations.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 21, AppUserId = null },
new Comment { Id = 48, Title = "Ad Tier Growth", Content = "The ad-supported tier is a whole new revenue stream with big upside.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 21, AppUserId = null },

// AMD - 4 comments
new Comment { Id = 49, Title = "Data Center Push", Content = "MI300X is gaining real traction against Nvidia in AI workloads.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 22, AppUserId = null },
new Comment { Id = 50, Title = "PC Recovery", Content = "Gaming GPU and laptop CPU cycles look set to recover this year.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 22, AppUserId = null },
new Comment { Id = 51, Title = "EPYC Dominance", Content = "EPYC server CPUs keep taking share from Intel in data centers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 22, AppUserId = null },
new Comment { Id = 52, Title = "Lisa Su Effect", Content = "AMD's turnaround under Lisa Su is one of tech's best CEO stories.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 22, AppUserId = null },

// ORCL - 1 comment
new Comment { Id = 53, Title = "Cloud Acceleration", Content = "OCI is winning large AI training contracts no one expected.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 23, AppUserId = null },

// CVX - 3 comments
new Comment { Id = 54, Title = "Hess Deal", Content = "The Hess acquisition brings great Guyana deepwater assets onboard.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 24, AppUserId = null },
new Comment { Id = 55, Title = "Shareholder Returns", Content = "CVX's buyback program is among the best in the energy sector.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 24, AppUserId = null },
new Comment { Id = 56, Title = "Oil Price Watch", Content = "Everything hinges on crude prices — keep an eye on OPEC+ decisions.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 24, AppUserId = null },

// HD - 2 comments
new Comment { Id = 57, Title = "Housing Cycle", Content = "HD will benefit big when mortgage rates eventually come down.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 25, AppUserId = null },
new Comment { Id = 58, Title = "Pro Segment", Content = "The Pro contractor segment is a high-margin and growing revenue driver.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 25, AppUserId = null },
// KO - 1 comment
new Comment { Id = 59, Title = "Dividend Aristocrat", Content = "KO has raised its dividend for over 60 consecutive years. Legendary.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 26, AppUserId = null },

// ABBV - 3 comments
new Comment { Id = 60, Title = "Post-Humira Transition", Content = "Skyrizi and Rinvoq are more than compensating for Humira losses.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 27, AppUserId = null },
new Comment { Id = 61, Title = "High Dividend Yield", Content = "ABBV pays a strong dividend while still actively growing its pipeline.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 27, AppUserId = null },
new Comment { Id = 62, Title = "Acquisition Strategy", Content = "Recent bolt-on acquisitions show management is thinking long-term.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 27, AppUserId = null },

// BAC - 2 comments
new Comment { Id = 63, Title = "Rate Sensitivity", Content = "BAC is highly leveraged to interest rates — watch the Fed closely.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 28, AppUserId = null },
new Comment { Id = 64, Title = "Consumer Banking", Content = "Massive consumer deposit base is a durable competitive advantage.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 28, AppUserId = null },
// PG - 1 comment
new Comment { Id = 65, Title = "Steady Compounder", Content = "PG is boring in the best possible way. Reliable decade after decade.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 29, AppUserId = null },

// PEP - 4 comments
new Comment { Id = 66, Title = "Snacks Powerhouse", Content = "Frito-Lay alone is arguably worth the entire investment in PepsiCo.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 30, AppUserId = null },
new Comment { Id = 67, Title = "Volume Pressure", Content = "Beverage volume softness is worth monitoring over the next few quarters.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 30, AppUserId = null },
new Comment { Id = 68, Title = "International Growth", Content = "Emerging market expansion is a quiet but steady growth engine.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 30, AppUserId = null },
new Comment { Id = 69, Title = "Dividend Growth", Content = "PEP has raised its dividend for over 50 years. Hard to ignore.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 30, AppUserId = null },

// CRM - 2 comments
new Comment { Id = 70, Title = "AI Agents", Content = "Agentforce could become a major new revenue stream for Salesforce.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 31, AppUserId = null },
new Comment { Id = 71, Title = "Margin Expansion", Content = "Salesforce is finally delivering the profitability investors wanted.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 31, AppUserId = null },

// ADBE - 1 comment
new Comment { Id = 72, Title = "AI Disruption Risk", Content = "Generative AI tools could commoditize parts of Adobe's creative suite.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 32, AppUserId = null },

// NKE - 3 comments
new Comment { Id = 73, Title = "Brand Turnaround", Content = "New leadership needs to reinvigorate wholesale channels and product innovation.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 33, AppUserId = null },
new Comment { Id = 74, Title = "China Recovery", Content = "Any recovery in China consumer spending would significantly help NKE.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 33, AppUserId = null },
new Comment { Id = 75, Title = "Valuation Reset", Content = "NKE is trading at a much more reasonable valuation than it was two years ago.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 33, AppUserId = null },

// DIS - 2 comments
new Comment { Id = 76, Title = "Streaming Profitability", Content = "Disney+ finally turning profitable is a major long-awaited milestone.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 34, AppUserId = null },
new Comment { Id = 77, Title = "Parks Resilience", Content = "Theme park demand has stayed far stronger than many analysts expected.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 34, AppUserId = null },
// TM - 1 comment
new Comment { Id = 78, Title = "Hybrid Leader", Content = "Toyota's hybrid lineup keeps outselling pure EVs in most global markets.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 35, AppUserId = null },

// AZN - 4 comments
new Comment { Id = 79, Title = "Oncology Pipeline", Content = "AZN's cancer drug portfolio is one of the very best in all of pharma.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 36, AppUserId = null },
new Comment { Id = 80, Title = "China Exposure", Content = "AZN has meaningful China revenue which adds real political risk.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 36, AppUserId = null },
new Comment { Id = 81, Title = "Rare Disease Bets", Content = "Rare disease acquisitions could add significant future revenue streams.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 36, AppUserId = null },
new Comment { Id = 82, Title = "Tagrisso Growth", Content = "Tagrisso remains a dominant lung cancer treatment with strong revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 36, AppUserId = null },

// INTC - 2 comments
new Comment { Id = 83, Title = "Foundry Bet", Content = "Intel Foundry is a massive multi-year bet that will take time to play out.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 37, AppUserId = null },
new Comment { Id = 84, Title = "Market Share Loss", Content = "AMD and Arm-based chips keep eating into Intel's data center share.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 37, AppUserId = null },
// PLTR - 3 comments
new Comment { Id = 85, Title = "AIP Traction", Content = "Palantir's AI Platform is gaining strong momentum in enterprise.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 38, AppUserId = null },
new Comment { Id = 86, Title = "Valuation Debate", Content = "PLTR's valuation is extremely stretched relative to current revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 38, AppUserId = null },
new Comment { Id = 87, Title = "Government Contracts", Content = "Defense and intelligence contracts provide very stable recurring revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 38, AppUserId = null },
// BABA - 1 comment
new Comment { Id = 88, Title = "Cheap Valuation", Content = "Trading at low multiples makes BABA tempting for patient value investors.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 39, AppUserId = null },

// PFE - 2 comments
new Comment { Id = 89, Title = "Post-COVID Reset", Content = "Pfizer is working hard to replace the massive lost COVID vaccine revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 40, AppUserId = null },
new Comment { Id = 90, Title = "Pipeline Watch", Content = "Oncology-focused acquisitions could meaningfully restock the pipeline.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 40, AppUserId = null },

// CAT - 4 comments
new Comment { Id = 91, Title = "Infrastructure Boom", Content = "CAT benefits directly from global infrastructure and construction spending.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 41, AppUserId = null },
new Comment { Id = 92, Title = "Mining Demand", Content = "Mining equipment demand remains strong with commodity prices elevated.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 41, AppUserId = null },
new Comment { Id = 93, Title = "Services Growth", Content = "CAT's aftermarket parts and services segment has incredible margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 41, AppUserId = null },
new Comment { Id = 94, Title = "Backlog Strength", Content = "Order backlogs remain healthy pointing to strong revenue ahead.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 41, AppUserId = null },

// CSCO - 1 comment
new Comment { Id = 95, Title = "AI Networking", Content = "AI data centers need massive networking upgrades — Cisco is well placed.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 42, AppUserId = null },

// IBM - 3 comments
new Comment { Id = 96, Title = "Hybrid Cloud Focus", Content = "IBM's Red Hat continues to be a solid enterprise hybrid cloud play.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 43, AppUserId = null },
new Comment { Id = 97, Title = "AI Consulting", Content = "watsonx is IBM's enterprise AI bet and early adoption signs are decent.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 43, AppUserId = null },
new Comment { Id = 98, Title = "Steady Dividend", Content = "IBM keeps paying a reliable dividend while quietly modernizing itself.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 43, AppUserId = null },

// GS - 2 comments
new Comment { Id = 99, Title = "IB Recovery", Content = "Investment banking deal flow is finally picking up after a tough cycle.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 44, AppUserId = null },
new Comment { Id = 100, Title = "Consumer Exit", Content = "Pulling back from consumer banking was clearly the right strategic call.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 44, AppUserId = null },
// MCD - 1 comment
new Comment { Id = 101, Title = "Franchise Model", Content = "The asset-light franchise model generates incredibly consistent cash flow.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 45, AppUserId = null },

// SBUX - 4 comments
new Comment { Id = 102, Title = "Turnaround Watch", Content = "New CEO Brian Niccol needs to fix both traffic trends and brand perception.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 46, AppUserId = null },
new Comment { Id = 103, Title = "China Weakness", Content = "China comp sales remain under heavy pressure from aggressive local rivals.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 46, AppUserId = null },
new Comment { Id = 104, Title = "Menu Simplification", Content = "Cutting back the menu complexity is a smart operational move.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 46, AppUserId = null },
new Comment { Id = 105, Title = "Loyalty Program", Content = "Starbucks Rewards membership is a genuinely powerful retention engine.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 46, AppUserId = null },

// UPS - 2 comments
new Comment { Id = 106, Title = "Volume Recovery", Content = "Parcel volume is slowly recovering as e-commerce spending stabilizes.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 47, AppUserId = null },
new Comment { Id = 107, Title = "Amazon Risk", Content = "Amazon building its own logistics network is a serious long-term threat.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 47, AppUserId = null },

// BX - 1 comment
new Comment { Id = 108, Title = "AUM Growth", Content = "Blackstone keeps breaking records on assets under management every quarter.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 48, AppUserId = null },

// QCOM - 3 comments
new Comment { Id = 109, Title = "Snapdragon PC Push", Content = "Arm-based Windows PCs powered by Snapdragon are genuinely gaining ground.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 49, AppUserId = null },
new Comment { Id = 110, Title = "Apple Dependency", Content = "Losing Apple as a modem customer was a more significant blow than expected.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 49, AppUserId = null },
new Comment { Id = 111, Title = "Auto Chips", Content = "Automotive chip wins are diversifying QCOM beyond just smartphones.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 49, AppUserId = null },

// ABT - 2 comments
new Comment { Id = 112, Title = "CGM Leader", Content = "FreeStyle Libre dominates the continuous glucose monitoring market globally.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 50, AppUserId = null },
new Comment { Id = 113, Title = "Diversified Medtech", Content = "Abbott's mix of diagnostics, devices and nutrition is impressively balanced.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 50, AppUserId = null },
// TXN (StockId = 51) - 3 comments
new Comment { Id = 114, Title = "Analog Giant", Content = "Analog chips are in everything. High capital spending now will pay off later.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 51, AppUserId = null },
new Comment { Id = 115, Title = "Capital Allocation", Content = "TI's management has historically been top-tier at returning capital to shareholders.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 51, AppUserId = null },
new Comment { Id = 116, Title = "Cyclical Trough", Content = "Industrial demand weakness looks close to bottoming out.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 51, AppUserId = null },

// INTU (StockId = 52) - 2 comments
new Comment { Id = 117, Title = "Sticky Platform", Content = "QuickBooks and TurboTax create an incredible ecosystem with pricing power.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 52, AppUserId = null },
new Comment { Id = 118, Title = "Credit Karma Synergies", Content = "Consumer finance segment is expanding despite macro headwinds.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 52, AppUserId = null },

// NOW (StockId = 53) - 3 comments
new Comment { Id = 119, Title = "Enterprise Standard", Content = "ServiceNow is essential for IT workflows across Fortune 500 companies.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 53, AppUserId = null },
new Comment { Id = 120, Title = "GenAI Monetization", Content = "Pro Plus AI tiers are driving average contract value up significantly.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 53, AppUserId = null },
new Comment { Id = 121, Title = "Retention Beast", Content = "Renewal rate staying above 98% is practically unheard of in SaaS.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 53, AppUserId = null },

// AMAT (StockId = 54) - 2 comments
new Comment { Id = 122, Title = "Semiconductor Backbone", Content = "You can't manufacture advanced nodes without Applied Materials tools.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 54, AppUserId = null },
new Comment { Id = 123, Title = "WFE Spending", Content = "Wafer fab equipment demand will spike as new fabs open worldwide.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 54, AppUserId = null },

// BKNG (StockId = 55) - 2 comments
new Comment { Id = 124, Title = "Travel Dominance", Content = "Booking Holdings controls online travel booking with supreme margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 55, AppUserId = null },
new Comment { Id = 125, Title = "Aggressive Buybacks", Content = "Share reduction over time has been an incredible compounding engine.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 55, AppUserId = null },

// ISRG (StockId = 56) - 3 comments
new Comment { Id = 126, Title = "da Vinci Moat", Content = "Surgeon training and switching costs make Intuitive Surgical unbeatable.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 56, AppUserId = null },
new Comment { Id = 127, Title = "Procedure Growth", Content = "Procedure volumes continue to grow strongly worldwide.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 56, AppUserId = null },
new Comment { Id = 128, Title = "da Vinci 5 Launch", Content = "The next-gen system rollout will drive system placements for years.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 56, AppUserId = null },

// Uber (StockId = 57) - 3 comments
new Comment { Id = 129, Title = "Free Cash Flow Pivot", Content = "Uber went from burning money to a cash generation powerhouse.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 57, AppUserId = null },
new Comment { Id = 130, Title = "Eats & Mobility", Content = "Dual platform creates cross-selling advantages competitors lack.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 57, AppUserId = null },
new Comment { Id = 131, Title = "Autonomous Threat", Content = "Robotaxis could disrupt their model long-term if they don't partner right.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 57, AppUserId = null },

// GE (StockId = 58) - 2 comments
new Comment { Id = 132, Title = "Aerospace Pure Play", Content = "Post-spinoff GE Aerospace is a high-margin, pure aviation engine powerhouse.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 58, AppUserId = null },
new Comment { Id = 133, Title = "Aftermarket Demand", Content = "Commercial flight demand keeps maintenance and spares revenue surging.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 58, AppUserId = null },

// UNH (StockId = 59) - 4 comments
new Comment { Id = 134, Title = "Healthcare Titan", Content = "Optum + UnitedHealthcare creates an unparalleled healthcare footprint.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 59, AppUserId = null },
new Comment { Id = 135, Title = "Medical Loss Ratio", Content = "Rising care utilization is exerting short-term pressure on MLR.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 59, AppUserId = null },
new Comment { Id = 136, Title = "Cyberattack Recovery", Content = "Change Healthcare incident caused pain, but structural dominance remains intact.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 59, AppUserId = null },
new Comment { Id = 137, Title = "Long-term Compounder", Content = "One of the best long-term total return stocks in modern history.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 59, AppUserId = null },

// PM (StockId = 60) - 2 comments
new Comment { Id = 138, Title = "Smoke-Free Transition", Content = "IQOS and ZYN are driving a successful transformation away from cigarettes.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 60, AppUserId = null },
new Comment { Id = 139, Title = "High Yield", Content = "Dependable dividend yield backed by resilient smoke-free growth.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 60, AppUserId = null },

// LOW (StockId = 61) - 2 comments
new Comment { Id = 140, Title = "Retail Rival", Content = "Lowe's PPI improvements are helping close the margin gap with Home Depot.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 61, AppUserId = null },
new Comment { Id = 141, Title = "Housing Lock-in", Content = "Low existing home sales drag DIY spending, but pent-up demand is building.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 61, AppUserId = null },

// SPGI (StockId = 62) - 3 comments
new Comment { Id = 142, Title = "Ratings Tollbooth", Content = "Corporate debt issuance is an essential tollbooth for S&P Global.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 62, AppUserId = null },
new Comment { Id = 143, Title = "Data Moat", Content = "Financial data subscriptions provide recurring high-margin cash flow.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 62, AppUserId = null },
new Comment { Id = 144, Title = "Refinancing Wave", Content = "Upcoming debt maturities will accelerate credit rating revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 62, AppUserId = null },

// PANW (StockId = 63) - 3 comments
new Comment { Id = 145, Title = "Platformization", Content = "Consolidating security vendors into Palo Alto's platform is working.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 63, AppUserId = null },
new Comment { Id = 146, Title = "Cyber Essential", Content = "Cybersecurity budgets remain resilient even during economic slowdowns.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 63, AppUserId = null },
new Comment { Id = 147, Title = "Short-term Friction", Content = "Free promotional offers to win market share create temporary revenue noise.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 63, AppUserId = null },

// LRCX (StockId = 64) - 2 comments
new Comment { Id = 148, Title = "Etch & Deposition", Content = "Lam Research is indispensable for 3D NAND and advanced DRAM scaling.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 64, AppUserId = null },
new Comment { Id = 149, Title = "Memory Recovery", Content = "Memory market rebound will benefit Lam Research faster than peers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 64, AppUserId = null },

// SYK (StockId = 65) - 2 comments
new Comment { Id = 150, Title = "Robotic Surgery", Content = "Mako robotic arm system is winning orthopedic market share globally.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 65, AppUserId = null },
new Comment { Id = 151, Title = "Elective Procedures", Content = "Consistent hip and knee replacement volumes support stable earnings.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 65, AppUserId = null },

// SCHW (StockId = 66) - 2 comments
new Comment { Id = 152, Title = "Cash Sorting Relief", Content = "Cash sorting headwinds are finally abating as client sweep cash stabilizes.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 66, AppUserId = null },
new Comment { Id = 153, Title = "TD Ameritrade Integration", Content = "Integration synergies are unlocking operating leverage for Schwab.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 66, AppUserId = null },

// MS (StockId = 67) - 3 comments
new Comment { Id = 154, Title = "Wealth Machine", Content = "Morgan Stanley's pivot to wealth management created steady fee revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 67, AppUserId = null },
new Comment { Id = 155, Title = "AUM Inflows", Content = "Net new asset inflows continue to prove their franchise strength.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 67, AppUserId = null },
new Comment { Id = 156, Title = "Capital Markets Rebound", Content = "Advisory and underwriting fees are ramping back up nicely.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 67, AppUserId = null },

// KLAC (StockId = 68) - 2 comments
new Comment { Id = 157, Title = "Process Control Leader", Content = "Process control and yield management is 100% vital as chip nodes shrink.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 68, AppUserId = null },
new Comment { Id = 158, Title = "Pricing Dominance", Content = "KLA enjoys virtually no direct competition in high-end optical inspection.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 68, AppUserId = null },

// TGT (StockId = 69) - 2 comments
new Comment { Id = 159, Title = "Inventory Management", Content = "Target has cleared bad inventory and margins are recovering.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 69, AppUserId = null },
new Comment { Id = 160, Title = "Discretionary Pressures", Content = "Higher mix of apparel and home goods leaves it exposed to consumer pullbacks.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 69, AppUserId = null },

// DE (StockId = 70) - 3 comments
new Comment { Id = 161, Title = "Precision Ag", Content = "Deere's tech stack in autonomous tractors gives it a huge advantage.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 70, AppUserId = null },
new Comment { Id = 162, Title = "Farm Income Cycle", Content = "Lower crop prices are impacting short-term equipment replacement cycles.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 70, AppUserId = null },
new Comment { Id = 163, Title = "Software Subscriptions", Content = "Recurring software revenue from precision farming will smooth out cycles.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 70, AppUserId = null },

// ABNB (StockId = 71) - 3 comments
new Comment { Id = 164, Title = "Network Effects", Content = "Global brand awareness lets Airbnb spend far less on performance marketing.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 71, AppUserId = null },
new Comment { Id = 165, Title = "Regulatory Pushback", Content = "City-level restrictions (like NYC) remain a regional risk factor.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 71, AppUserId = null },
new Comment { Id = 166, Title = "Long-term Stays", Content = "Remote work trends continue to support stays of 28 days or longer.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 71, AppUserId = null },

// CRM (StockId = 72) - 2 comments
new Comment { Id = 167, Title = "Enterprise Standard", Content = "Customer Relationship Management software remains core to business ops.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 72, AppUserId = null },
new Comment { Id = 168, Title = "Data Cloud Push", Content = "Data Cloud is turning into their fastest-growing product segment.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 72, AppUserId = null },

// SNOW (StockId = 73) - 3 comments
new Comment { Id = 169, Title = "Consumption Model", Content = "Consumption-based pricing means immediate upside when usage spikes.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 73, AppUserId = null },
new Comment { Id = 170, Title = "Data Cloud Leader", Content = "Multi-cloud capability makes Snowflake the neutral data platform choice.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 73, AppUserId = null },
new Comment { Id = 171, Title = "High Valuation", Content = "Multiples are rich, leaving little room for execution missteps.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 73, AppUserId = null },

// MDB (StockId = 74) - 2 comments
new Comment { Id = 172, Title = "Document Database Standard", Content = "MongoDB Atlas is the default choice for modern application developers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 74, AppUserId = null },
new Comment { Id = 173, Title = "Vector Search AI", Content = "Integrated vector search makes MDB a key player in GenAI application stacks.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 74, AppUserId = null },

// SHOP (StockId = 75) - 3 comments
new Comment { Id = 174, Title = "E-Commerce OS", Content = "Shopify is the underlying infrastructure for modern independent DTC brands.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 75, AppUserId = null },
new Comment { Id = 175, Title = "Logistics Exit", Content = "Selling off Deliverr restored margin expansion and focus to core software.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 75, AppUserId = null },
new Comment { Id = 176, Title = "Enterprise Penetration", Content = "Shopify Plus is successfully winning larger enterprise retailers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 75, AppUserId = null },

// SQ (StockId = 76) - 3 comments
new Comment { Id = 177, Title = "Cash App Monetization", Content = "Cash App continues to gain market share as a primary banking option for Gen Z.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 76, AppUserId = null },
new Comment { Id = 178, Title = "Gross Profit Focus", Content = "Block management is finally prioritizing disciplined operating expenses.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 76, AppUserId = null },
new Comment { Id = 179, Title = "Seller Ecosystem", Content = "Square point-of-sale hardware and software integration keeps merchant churn low.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 76, AppUserId = null },

// PYPL (StockId = 77) - 3 comments
new Comment { Id = 180, Title = "Value Play", Content = "Trading at historically low multiples despite massive transaction volume.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 77, AppUserId = null },
new Comment { Id = 181, Title = "Braintree Growth", Content = "Unbranded processing volume is booming, though at lower margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 77, AppUserId = null },
new Comment { Id = 182, Title = "Fast Checkout Turnaround", Content = "Fastlane checkout could help defend branded button market share.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 77, AppUserId = null },

// NET (StockId = 78) - 3 comments
new Comment { Id = 183, Title = "Edge Computing Leader", Content = "Cloudflare Workers gives them a massive edge in running AI at the edge.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 78, AppUserId = null },
new Comment { Id = 184, Title = "Zero Trust Push", Content = "Winning enterprise market share away from traditional legacy security players.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 78, AppUserId = null },
new Comment { Id = 185, Title = "High Sales Overhead", Content = "Go-to-market execution needs improvement to drive faster profitability.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 78, AppUserId = null },

// CRWD (StockId = 79) - 3 comments
new Comment { Id = 186, Title = "Falcon Platform", Content = "Falcon single-agent architecture makes module adoption effortless.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 79, AppUserId = null },
new Comment { Id = 187, Title = "Outage Incident Recovery", Content = "Operational hiccups cause temporary volatility, but fundamental tech is superior.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 79, AppUserId = null },
new Comment { Id = 188, Title = "ARR Compounder", Content = "Annual recurring revenue growth remains near the top of pure-play cybersecurity.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 79, AppUserId = null },

// ZS (StockId = 80) - 2 comments
new Comment { Id = 189, Title = "Zero Trust Pioneer", Content = "Zscaler is a leader in cloud security and secure access service edge (SASE).", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 80, AppUserId = null },
new Comment { Id = 190, Title = "Enterprise Expansion", Content = "Upselling existing clients to full platform protection continues to succeed.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 80, AppUserId = null },

// DDOG (StockId = 81) - 3 comments
new Comment { Id = 191, Title = "Observability Standard", Content = "Datadog is the preferred monitoring solution for modern cloud applications.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 81, AppUserId = null },
new Comment { Id = 192, Title = "LLM Monitoring", Content = "New AI integration monitoring features create fresh upsell opportunities.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 81, AppUserId = null },
new Comment { Id = 193, Title = "Cloud Optimization Bottoming", Content = "Customers are done cutting cloud usage, shifting back to growth spend.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 81, AppUserId = null },

// COIN (StockId = 82) - 3 comments
new Comment { Id = 194, Title = "Institutional Gateway", Content = "Coinbase serving as custodian for major Bitcoin ETFs gives immense credibility.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 82, AppUserId = null },
new Comment { Id = 195, Title = "Base L2 Growth", Content = "Base network adoption creates a new high-margin revenue lever beyond trading fees.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 82, AppUserId = null },
new Comment { Id = 196, Title = "Regulatory Clarity", Content = "Improving regulatory frameworks will reduce long-term valuation overhang.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 82, AppUserId = null },

// HOOD (StockId = 83) - 4 comments
new Comment { Id = 197, Title = "Retail Active Revival", Content = "Crypto and options trading activity resurgence boosts Robinhood revenues.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 83, AppUserId = null },
new Comment { Id = 198, Title = "Gold Membership Value", Content = "5% yield on uninvested cash is bringing substantial net deposits to the platform.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 83, AppUserId = null },
new Comment { Id = 199, Title = "International Expansion", Content = "UK and EU launches broaden the addressable market outside the US.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 83, AppUserId = null },
new Comment { Id = 200, Title = "Operating Leverage", Content = "Disciplined headcount control is finally letting top-line gains drop to the bottom line.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 83, AppUserId = null },
// AFRM (StockId = 84) - 3 comments
new Comment { Id = 201, Title = "BNPL Pioneer", Content = "Affirm is consolidating its position as the premier buy-now-pay-later provider for enterprise checkouts.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 84, AppUserId = null },
new Comment { Id = 202, Title = "Shopify & Amazon Deals", Content = "Key checkout integrations provide massive volume growth without high acquisition costs.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 84, AppUserId = null },
new Comment { Id = 203, Title = "Credit Performance", Content = "Underwriting algorithms are holding up well despite higher baseline interest rates.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 84, AppUserId = null },

// PLTR (StockId = 85) - 4 comments
new Comment { Id = 204, Title = "AIP Demand Boom", Content = "Artificial Intelligence Platform (AIP) bootcamps are driving unprecedented commercial growth in the US.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 85, AppUserId = null },
new Comment { Id = 205, Title = "Defense Moat", Content = "Unshakeable monopoly in defense and intelligence sector government contracts.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 85, AppUserId = null },
new Comment { Id = 206, Title = "S&P 500 Catalyst", Content = "S&P 500 inclusion unlock institutional capital inflows and legitimizes profitability.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 85, AppUserId = null },
new Comment { Id = 207, Title = "Valuation Overhang", Content = "Multiples are priced for perfection; any growth deceleration could trigger short-term pullback.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 85, AppUserId = null },

// PATH (StockId = 86) - 3 comments
new Comment { Id = 208, Title = "RPA Dominance", Content = "UiPath remains the clear gold standard in Robotic Process Automation.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 86, AppUserId = null },
new Comment { Id = 209, Title = "Agentic AI Synergy", Content = "Integrating AI agents with business processes significantly increases software utility.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 86, AppUserId = null },
new Comment { Id = 210, Title = "Leadership Transition", Content = "Management changes created temporary uncertainty, but core fundamentals remain sound.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 86, AppUserId = null },

// U (StockId = 87) - 3 comments
new Comment { Id = 211, Title = "Mobile Engine Power", Content = "Unity controls the underlying game engine for over half of all mobile games globally.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 87, AppUserId = null },
new Comment { Id = 212, Title = "Runtime Fee Reset", Content = "Canceling the controversial runtime fee has restored vital trust with indie developers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 87, AppUserId = null },
new Comment { Id = 213, Title = "Ad Network Turnaround", Content = "Vectoring back toward core engine and advertising monetizations will take time.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 87, AppUserId = null },

// RBLX (StockId = 88) - 3 comments
new Comment { Id = 214, Title = "Metaverse Standard", Content = "Roblox is the only consumer platform successfully delivering real metaverse scale.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 88, AppUserId = null },
new Comment { Id = 215, Title = "Aging-Up Demographic", Content = "Over-13 user cohort is expanding rapidly, driving higher average spend per booking.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 88, AppUserId = null },
new Comment { Id = 216, Title = "Immersive Advertising", Content = "In-game brand partnerships offer a brand-new monetization avenue with huge potential.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 88, AppUserId = null },

// ARM (StockId = 89) - 3 comments
new Comment { Id = 217, Title = "Architecture Royalty", Content = "Arm v9 architecture adoption yields nearly double the royalty rate of previous generations.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 89, AppUserId = null },
new Comment { Id = 218, Title = "PC & Data Center Shift", Content = "Windows on Arm and custom hyperscaler chips are breaking x86 legacy control.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 89, AppUserId = null },
new Comment { Id = 219, Title = "High Lock-in", Content = "Virtually impossible for mobile chip designers to switch away from Arm IP.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 89, AppUserId = null },

// SMCI (StockId = 90) - 3 comments
new Comment { Id = 220, Title = "Liquid Cooling Tech", Content = "Super Micro leads the market in direct liquid cooling for dense GPU cluster deployments.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 90, AppUserId = null },
new Comment { Id = 221, Title = "Margin Pressure", Content = "Hyperscaler custom build demand brings high sales volume but lower gross margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 90, AppUserId = null },
new Comment { Id = 222, Title = "Governance & Filing", Content = "Internal control reviews and delayed filings have introduced noticeable stock volatility.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 90, AppUserId = null },

// ANET (StockId = 91) - 3 comments
new Comment { Id = 223, Title = "Data Center Switching", Content = "Arista Networks continues capturing market share from Cisco in cloud data centers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 91, AppUserId = null },
new Comment { Id = 224, Title = "Ethernet for AI", Content = "Ultra-Ethernet Consortium push favors Arista over proprietary InfiniBand in the long run.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 91, AppUserId = null },
new Comment { Id = 225, Title = "EOS Advantage", Content = "Extensible Operating System (EOS) gives clients unprecedented network programmability.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 91, AppUserId = null },

// DELL (StockId = 92) - 3 comments
new Comment { Id = 226, Title = "AI Server Surge", Content = "Dell PowerEdge AI servers are benefiting from massive enterprise backlog orders.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 92, AppUserId = null },
new Comment { Id = 227, Title = "PC Refresh Cycle", Content = "AI PC upgrades and Windows 10 end-of-life will stimulate commercial hardware refresh.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 92, AppUserId = null },
new Comment { Id = 228, Title = "Shareholder Return", Content = "Aggressive buybacks and growing dividend payout yield reliable cash return.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 92, AppUserId = null },

// HPQ (StockId = 93) - 3 comments
new Comment { Id = 229, Title = "Steady Cash Generator", Content = "HP Inc generates resilient free cash flow from printing supplies and enterprise PCs.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 93, AppUserId = null },
new Comment { Id = 230, Title = "Hybrid Work Solutions", Content = "Poly acquisition strengthens position in conference room and peripheral ecosystems.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 93, AppUserId = null },
new Comment { Id = 231, Title = "Value & Dividend", Content = "Attractive low valuation multiple supported by consistent share repurchases.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 93, AppUserId = null },

// STX (StockId = 94) - 3 comments
new Comment { Id = 232, Title = "HAMR Technology", Content = "Heat-Assisted Magnetic Recording (HAMR) enables Seagate to ship 30TB+ drives.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 94, AppUserId = null },
new Comment { Id = 233, Title = "Mass Capacity Storage", Content = "Hyperscale AI training requires vast cold storage HDD arrays.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 94, AppUserId = null },
new Comment { Id = 234, Title = "Cyclical Upswing", Content = "Cloud storage inventory digestion is over, leading to volume and pricing growth.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 94, AppUserId = null },

// WDC (StockId = 95) - 3 comments
new Comment { Id = 235, Title = "Business Separation", Content = "Splitting Flash Memory and HDD businesses unlocks latent shareholder value.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 95, AppUserId = null },
new Comment { Id = 236, Title = "NAND Price Recovery", Content = "Production cuts across memory makers restored NAND flash pricing power.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 95, AppUserId = null },
new Comment { Id = 237, Title = "Enterprise SSD Shift", Content = "High-performance enterprise SSD demand is surging due to AI server deployments.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 95, AppUserId = null },

// MU (StockId = 96) - 3 comments
new Comment { Id = 238, Title = "HBM3E Dominance", Content = "Micron's High Bandwidth Memory is locked into top-tier AI accelerator builds.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 96, AppUserId = null },
new Comment { Id = 239, Title = "Memory Supercycle", Content = "Tight supply and surge in AI RAM requirements create structural pricing tailwinds.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 96, AppUserId = null },
new Comment { Id = 240, Title = "Cyclical Volatility", Content = "Memory is inherently cyclical, requiring precise timing over the holding period.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 96, AppUserId = null },

// WDC / Custom Tech - TSM (StockId = 97) - 3 comments
new Comment { Id = 241, Title = "Foundry Monopoly", Content = "TSMC manufactures over 90% of the world's most advanced semiconductor logic chips.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 97, AppUserId = null },
new Comment { Id = 242, Title = "2nm N2 Node Leadership", Content = "GAAFET transition at 2nm maintains TSMC's multi-year lead over Intel and Samsung.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 97, AppUserId = null },
new Comment { Id = 243, Title = "Geopolitical Premium", Content = "Taiwan risk remains the sole discount factor on an otherwise flawless technology monopoly.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 97, AppUserId = null },

// ASML (StockId = 98) - 3 comments
new Comment { Id = 244, Title = "EUV Monopoly", Content = "ASML holds a absolute 100% market share in EUV lithography systems.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 98, AppUserId = null },
new Comment { Id = 245, Title = "High NA EUV", Content = "Next-generation High NA EUV systems priced at $350M+ each secure future revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 98, AppUserId = null },
new Comment { Id = 246, Title = "Export Restrictions", Content = "Limits on deep ultraviolet (DUV) shipments to China pose near-term headwinds.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 98, AppUserId = null },

// BABA (StockId = 99) - 3 comments
new Comment { Id = 247, Title = "Value Realization", Content = "Massive cash pile and share repurchases provide strong downside protection.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 99, AppUserId = null },
new Comment { Id = 248, Title = "Cloud Intelligence", Content = "Alibaba Cloud remains China's dominant public cloud provider.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 99, AppUserId = null },
new Comment { Id = 249, Title = "Domestic Competition", Content = "PDD Holdings and Douyin continue to pressure core Taobao and Tmall market share.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 99, AppUserId = null },

// PDD (StockId = 100) - 3 comments
new Comment { Id = 250, Title = "Temu Expansion", Content = "Temu is disrupting global cross-border value retail with direct manufacturer shipping.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 100, AppUserId = null },
new Comment { Id = 251, Title = "Domestic Efficiency", Content = "Pinduoduo domestic market monetization and take-rate keep beating expectations.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 100, AppUserId = null },
new Comment { Id = 252, Title = "Tariff Risks", Content = "Regulatory scrutiny on de minimis customs exemptions could impact Temu margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 100, AppUserId = null },

// JD (StockId = 101) - 3 comments
new Comment { Id = 253, Title = "Logistics Moat", Content = "JD's self-owned fulfillment network guarantees superior delivery service quality.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 101, AppUserId = null },
new Comment { Id = 254, Title = "Electronics Retail", Content = "Remains the go-to platform for Chinese home appliance and electronics consumer spend.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 101, AppUserId = null },
new Comment { Id = 255, Title = "Dividend Yield", Content = "Generous annual dividend payout offers high total return potential for value investors.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 101, AppUserId = null },

// BIDU (StockId = 102) - 3 comments
new Comment { Id = 256, Title = "ERNIE Bot & AI", Content = "Baidu leads Chinese generative AI deployment and LLM integration.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 102, AppUserId = null },
new Comment { Id = 257, Title = "Apollo Go Robotaxi", Content = "Apollo Go robotaxi scale in Wuhan shows commercial viability of fully autonomous fleets.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 102, AppUserId = null },
new Comment { Id = 258, Title = "Search Ad Drag", Content = "Core ad search engine business faces macro softness and video platform competition.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 102, AppUserId = null },

// TME (StockId = 259) - 3 comments
new Comment { Id = 259, Title = "Music Subscription Growth", Content = "Tencent Music is successfully executing a Spotify-style shift to paid subscriber monetization.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 103, AppUserId = null },
new Comment { Id = 260, Title = "ARPU Expansion", Content = "Average revenue per user is compounding steady year-over-year gains.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 103, AppUserId = null },
new Comment { Id = 261, Title = "Margin Expansion", Content = "Lower user acquisition costs drive rapid operating margin improvements.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 103, AppUserId = null },

// BILI (StockId = 104) - 3 comments
new Comment { Id = 262, Title = "Gen Z Engagement", Content = "Bilibili commands unmatched user stickiness among China's youth demographic.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 104, AppUserId = null },
new Comment { Id = 263, Title = "Gaming Monetization", Content = "Exclusive mobile game publishing releases are turning operating losses into profits.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 104, AppUserId = null },
new Comment { Id = 264, Title = "Ad Revenue Scaling", Content = "Performance advertising tools are enabling higher ad density without user churn.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 104, AppUserId = null },

// NIO (StockId = 105) - 3 comments
new Comment { Id = 265, Title = "Battery Swap Moat", Content = "Battery swapping network provides a unique competitive differentiator against Tesla.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 105, AppUserId = null },
new Comment { Id = 266, Title = "ONVO Mass Market", Content = "Sub-brand ONVO expands NIO's addressable market into mainstream vehicle buyers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 105, AppUserId = null },
new Comment { Id = 267, Title = "Cash Burn Concerns", Content = "Heavy infrastructure and R&D spending require disciplined balance sheet management.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 105, AppUserId = null },

// XPEV (StockId = 106) - 3 comments
new Comment { Id = 268, Title = "XNGP Autonomous Lead", Content = "XPeng is recognized as a technical leader in mapless urban autonomous driving in China.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 106, AppUserId = null },
new Comment { Id = 269, Title = "Volkswagen Partnership", Content = "Joint platform development with Volkswagen provides balance sheet and technical validation.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 106, AppUserId = null },
new Comment { Id = 270, Title = "Price War Heat", Content = "Aggressive discounting across Chinese EV makers limits gross margin expansion.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 106, AppUserId = null },

// LI (StockId = 107) - 3 comments
new Comment { Id = 271, Title = "EREV Cash Machine", Content = "Extended-Range Electric Vehicles (EREV) solved range anxiety and powered early profitability.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 107, AppUserId = null },
new Comment { Id = 272, Title = "Pure EV Rollout", Content = "MEGA and upcoming pure electric SUV models mark the next phase of growth.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 107, AppUserId = null },
new Comment { Id = 273, Title = "Best-in-Class Margins", Content = "Li Auto leads Chinese EV startups in unit economics and operating cash flow generation.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 107, AppUserId = null },

// RIVN (StockId = 108) - 3 comments
new Comment { Id = 274, Title = "R2 Platform Hype", Content = "Upcoming mass-market R2 platform will unlock broader consumer adoption.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 108, AppUserId = null },
new Comment { Id = 275, Title = "Volkswagen Joint Venture", Content = "Up to $5B capital injection from VW derisks Rivian's balance sheet long-term.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 108, AppUserId = null },
new Comment { Id = 276, Title = "Gross Margin Turnaround", Content = "Re-engineering the R1 line is crucial for reaching positive gross margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 108, AppUserId = null },

// LCID (StockId = 109) - 3 comments
new Comment { Id = 277, Title = "Efficiency Engineering", Content = "Lucid builds the single most energy-efficient electric powertrain in the market.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 109, AppUserId = null },
new Comment { Id = 278, Title = "Gravity SUV Launch", Content = "Lucid Gravity opens up the lucrative premium 3-row SUV segment.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 109, AppUserId = null },
new Comment { Id = 279, Title = "PIF Backing", Content = "Saudi Arabia Public Investment Fund funding guarantees liquid runway despite heavy burn.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 109, AppUserId = null },

// F (StockId = 110) - 3 comments
new Comment { Id = 280, Title = "Ford Pro Dominance", Content = "Ford Pro commercial division produces high margins and reliable software-fleet revenue.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 110, AppUserId = null },
new Comment { Id = 281, Title = "Model e Losses", Content = "First-gen EV division losses are being offset by strong Ford Blue ICE vehicle earnings.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 110, AppUserId = null },
new Comment { Id = 282, Title = "Capital Return", Content = "Supplemental dividends keep total payout yield highly attractive for dividend investors.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 110, AppUserId = null },

// GM (StockId = 111) - 3 comments
new Comment { Id = 283, Title = "Massive Share Shrink", Content = "GM is aggressively buying back shares, drastically reducing share count.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 111, AppUserId = null },
new Comment { Id = 284, Title = "Ultium Scaling", Content = "Battery production issues are resolving, paving the way for profitable EV volume.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 111, AppUserId = null },
new Comment { Id = 285, Title = "Cruise Autonomous Restructing", Content = "Cruise safety pauses hurt momentum, but long-term driverless tech value remains intact.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 111, AppUserId = null },

// STLA (StockId = 112) - 3 comments
new Comment { Id = 286, Title = "Cost Control Discipline", Content = "Stellantis maintains some of the highest operating profit margins among traditional automakers.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 112, AppUserId = null },
new Comment { Id = 287, Title = "Jeep & Ram Power", Content = "North American light truck and SUV sales generate the bulk of group profit.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 112, AppUserId = null },
new Comment { Id = 288, Title = "Inventory Headwinds", Content = "US dealer inventory overhang required pricing adjustments and production slowdowns.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 112, AppUserId = null },

// HMC (StockId = 113) - 3 comments
new Comment { Id = 289, Title = "Hybrid Demand Sweet Spot", Content = "Honda hybrid models are enjoying massive consumer demand during the transition phase.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 113, AppUserId = null },
new Comment { Id = 290, Title = "Motorcycle Cash Flow", Content = "Dominant global motorcycle business yields stable cash flows through all economic cycles.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 113, AppUserId = null },
new Comment { Id = 291, Title = "EV Software Strategy", Content = "0 Series EV launch marks Honda's dedicated attempt to modernize its electric platform.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 113, AppUserId = null },

// TM (StockId = 114 extra to reach 300) - 9 comments to hit Id = 300 exactly!
new Comment { Id = 292, Title = "Hybrid King", Content = "Toyota's long-term bet on hybrid vehicles proved to be an absolute masterclass in strategy.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 293, Title = "Record Earnings", Content = "Record global production numbers continue to produce record operating margins.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 294, Title = "Solid State Battery R&D", Content = "Massive investments in solid-state batteries could give Toyota a late-stage EV advantage.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 295, Title = "Supply Chain Resilience", Content = "Toyota Production System ensures smooth supply chain execution where others struggle.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 296, Title = "Branded Reliability", Content = "Unrivaled global consumer trust drives high resale values and customer retention.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 297, Title = "Yen Currency Tailwinds", Content = "Favorable Japanese Yen exchange rates boost exported earnings significantly.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 298, Title = "Multi-Pathway Strategy", Content = "Combining ICE, Hybrid, BEV, and Hydrogen spreads operational risk effectively.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 299, Title = "Certification Testing Governance", Content = "Domestic vehicle certification scandals caused minor operational delays, but long-term brand is intact.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null },
new Comment { Id = 300, Title = "Ultimate Automotive Anchor", Content = "Toyota represents the safest long-term core holding in the entire global auto sector.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 114, AppUserId = null }
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
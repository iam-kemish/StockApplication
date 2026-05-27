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
new Comment { Id = 113, Title = "Diversified Medtech", Content = "Abbott's mix of diagnostics, devices and nutrition is impressively balanced.", CreatedOn = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc), StockId = 50, AppUserId = null }
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
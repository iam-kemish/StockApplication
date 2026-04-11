using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Models;

namespace StockApplicationApi.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                new Stock { Id = 50, Symbol = "ABT", CompanyName = "Abbott Labs", Purchase = 115.40m, LastDiv = 0.55m, Industry = "Healthcare", MarketCap = 201000000000 }
                );

            modelBuilder.Entity<Comment>().HasData(
     // 1-10: Big Tech Sentiment
     new Comment { Id = 1, StockId = 1, Title = "GPU Lead is Insane", Content = "Nobody is catching NVDA on hardware. Blackwell is already sold out for the next 4 quarters.", CreatedOn = new DateTime(2026, 3, 10) },
     new Comment { Id = 2, StockId = 1, Title = "Overbought?", Content = "RSI is screaming overbought. I'm waiting for a 5% pullback before adding more.", CreatedOn = new DateTime(2026, 4, 1) },
     new Comment { Id = 3, StockId = 2, Title = "Services is the play", Content = "iPhone sales are flat, but the services revenue (App Store/iCloud) is where the real margin is.", CreatedOn = new DateTime(2026, 3, 15) },
     new Comment { Id = 4, StockId = 2, Title = "Walled Garden", Content = "The ecosystem lock-in is still the best in the world. Holding for the long term.", CreatedOn = new DateTime(2026, 3, 20) },
     new Comment { Id = 5, StockId = 3, Title = "Gemini Integration", Content = "The new multimodal search is actually starting to steal market share back from the competitors.", CreatedOn = new DateTime(2026, 4, 5) },
     new Comment { Id = 6, StockId = 3, Title = "Ad Spend", Content = "Digital ad spend is recovering. GOOGL is the primary beneficiary here.", CreatedOn = new DateTime(2026, 4, 6) },
     new Comment { Id = 7, StockId = 4, Title = "Azure Cloud", Content = "Microsoft Cloud growth is decelerating slightly, but still dominant in enterprise.", CreatedOn = new DateTime(2026, 3, 28) },
     new Comment { Id = 8, StockId = 4, Title = "Dividends", Content = "Reliable as always. Not a moonshot, but a bedrock for any portfolio.", CreatedOn = new DateTime(2026, 4, 2) },
     new Comment { Id = 9, StockId = 5, Title = "Logistics Cost", Content = "Amazon's last-mile delivery costs are dropping. Expect a beat on earnings.", CreatedOn = new DateTime(2026, 3, 12) },
     new Comment { Id = 10, StockId = 5, Title = "AWS Margin", Content = "AWS is basically a money printing machine at this point. Offsetting the retail losses.", CreatedOn = new DateTime(2026, 3, 22) },

     // 11-20: Semiconductors & Chips
     new Comment { Id = 11, StockId = 6, Title = "Geopolitical Risk", Content = "TSMC is the best company in the world, but the China-Taiwan tension makes me nervous.", CreatedOn = new DateTime(2026, 3, 5) },
     new Comment { Id = 12, StockId = 6, Title = "3nm Yields", Content = "Reports show 3nm yields are better than expected. Huge for the next gen chips.", CreatedOn = new DateTime(2026, 4, 8) },
     new Comment { Id = 13, StockId = 7, Title = "Networking Boom", Content = "Broadcom is the quiet winner of the AI race. Those custom ASICs are high margin.", CreatedOn = new DateTime(2026, 3, 30) },
     new Comment { Id = 14, StockId = 8, Title = "Ad Recovery", Content = "Meta's pivot back to its core ad business was the right move. Reels monetization is up.", CreatedOn = new DateTime(2026, 3, 18) },
     new Comment { Id = 15, StockId = 9, Title = "FSD Progress", Content = "Version 13 of FSD is actually usable. If they solve autonomy, the PE ratio makes sense.", CreatedOn = new DateTime(2026, 4, 9) },
     new Comment { Id = 16, StockId = 9, Title = "Competition", Content = "BYD and Xiaomi are eating Tesla's lunch in China. Scary trend.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 17, StockId = 12, Title = "Weight Loss Drugs", Content = "Zepbound demand is through the roof. LLY is now a biotech powerhouse.", CreatedOn = new DateTime(2026, 3, 25) },
     new Comment { Id = 18, StockId = 16, Title = "EUV Dominance", Content = "ASML literally has a monopoly on high-end lithography. You can't bet against them.", CreatedOn = new DateTime(2026, 4, 3) },
     new Comment { Id = 19, StockId = 22, Title = "AMD vs Intel", Content = "AMD is consistently taking server market share. EPYC chips are superior.", CreatedOn = new DateTime(2026, 3, 14) },
     new Comment { Id = 20, StockId = 38, Title = "AIP Adoption", Content = "Palantir's bootcamps are converting customers fast. The growth is finally here.", CreatedOn = new DateTime(2026, 4, 11) },

     // 21-40: Retail, Finance, Energy
     new Comment { Id = 21, StockId = 11, Title = "Defensive Play", Content = "If the economy slows down, everyone goes to Walmart. Safest stock right now.", CreatedOn = new DateTime(2026, 2, 28) },
     new Comment { Id = 22, StockId = 13, Title = "Interest Rates", Content = "Higher for longer means JPM keeps printing net interest income.", CreatedOn = new DateTime(2026, 3, 1) },
     new Comment { Id = 23, StockId = 15, Title = "Oil Prices", Content = "Brent oil hitting $90 is great for Exxon's cash flow.", CreatedOn = new DateTime(2026, 4, 4) },
     new Comment { Id = 24, StockId = 20, Title = "Membership Growth", Content = "Costco just raised the membership fee and nobody left. That is brand power.", CreatedOn = new DateTime(2026, 3, 21) },
     new Comment { Id = 25, StockId = 26, Title = "Dividend King", Content = "Doesn't matter if it's a recession or a boom, people drink Coke.", CreatedOn = new DateTime(2026, 1, 15) },
     new Comment { Id = 26, StockId = 33, Title = "Brand Fatigue", Content = "Nike is losing its edge to Hoka and On. Need more innovation in the lineup.", CreatedOn = new DateTime(2026, 4, 7) },
     new Comment { Id = 27, StockId = 34, Title = "Streaming Losses", Content = "Disney+ is finally profitable, but the parks are carrying the whole company.", CreatedOn = new DateTime(2026, 3, 11) },
     new Comment { Id = 28, StockId = 45, Title = "Global Scale", Content = "MCD is the ultimate inflation hedge. People still need cheap calories.", CreatedOn = new DateTime(2026, 3, 9) },
     new Comment { Id = 29, StockId = 37, Title = "Foundry Dreams", Content = "Intel is a 5-year play. If they can build a foundry business, they win.", CreatedOn = new DateTime(2026, 4, 2) },
     new Comment { Id = 30, StockId = 24, Title = "Yield Play", Content = "Chevron's 4% yield is why I hold it. Solid management and buybacks.", CreatedOn = new DateTime(2026, 3, 17) },
     new Comment { Id = 31, StockId = 10, Title = "Cash Pile", Content = "Buffett is sitting on a massive cash pile. Waiting for a crash to buy.", CreatedOn = new DateTime(2026, 2, 10) },
     new Comment { Id = 32, StockId = 14, Title = "Travel Rebound", Content = "Visa is benefiting from the huge spike in international travel spending.", CreatedOn = new DateTime(2026, 3, 29) },
     new Comment { Id = 33, StockId = 19, Title = "Fintech Fear", Content = "Mastercard isn't scared of crypto. They are integrating it. Smart.", CreatedOn = new DateTime(2026, 3, 27) },
     new Comment { Id = 34, StockId = 21, Title = "Password Crackdown", Content = "Netflix password sharing ban worked. Subscribers are way up.", CreatedOn = new DateTime(2026, 4, 1) },
     new Comment { Id = 35, StockId = 23, Title = "Cloud Pivot", Content = "Oracle is no longer a legacy company. Their OCI is actually good.", CreatedOn = new DateTime(2026, 4, 5) },
     new Comment { Id = 36, StockId = 25, Title = "Housing Market", Content = "High interest rates are hurting Home Depot. People aren't remodeling.", CreatedOn = new DateTime(2026, 2, 20) },
     new Comment { Id = 37, StockId = 31, Title = "SaaS Saturation", Content = "Salesforce is struggling to find new growth. The AI pivot needs to work.", CreatedOn = new DateTime(2026, 3, 3) },
     new Comment { Id = 38, StockId = 44, Title = "M&A Activity", Content = "Investment banking is waking up. Good news for Goldman.", CreatedOn = new DateTime(2026, 4, 9) },
     new Comment { Id = 39, StockId = 46, Title = "China Headwinds", Content = "Starbucks is getting crushed by local competition in China. Concern.", CreatedOn = new DateTime(2026, 4, 11) },
     new Comment { Id = 40, StockId = 41, Title = "Infrastructure Bill", Content = "Caterpillar is the main play for the US infrastructure rebuild.", CreatedOn = new DateTime(2026, 3, 23) },

     // 41-70: Mixed Bag & Specialized
     new Comment { Id = 41, StockId = 1, Title = "The New Gold", Content = "Compute is the new oil, and Nvidia owns the wells.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 42, StockId = 12, Title = "Supply Chain", Content = "If Eli Lilly can fix the Zepbound supply, this hits $1000 easily.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 43, StockId = 32, Title = "Firefly AI", Content = "Adobe's AI tools are preventing users from switching to Canva.", CreatedOn = new DateTime(2026, 3, 19) },
     new Comment { Id = 44, StockId = 35, Title = "Hybrid Strategy", Content = "Toyota was right about hybrids. Everyone is dumping pure EVs for them.", CreatedOn = new DateTime(2026, 4, 4) },
     new Comment { Id = 45, StockId = 39, Title = "Deep Value", Content = "BABA is trading at a ridiculous multiple. Too cheap to ignore.", CreatedOn = new DateTime(2026, 3, 31) },
     new Comment { Id = 46, StockId = 40, Title = "Pipeline Woes", Content = "Pfizer needs a new blockbuster drug. COVID revenue is long gone.", CreatedOn = new DateTime(2026, 4, 1) },
     new Comment { Id = 47, StockId = 42, Title = "Security Growth", Content = "Cisco's acquisition of Splunk is a game changer for their security stack.", CreatedOn = new DateTime(2026, 3, 25) },
     new Comment { Id = 48, StockId = 47, Title = "Automation", Content = "UPS is aggressively automating hubs to lower union labor costs.", CreatedOn = new DateTime(2026, 3, 14) },
     new Comment { Id = 49, StockId = 48, Title = "Private Credit", Content = "Blackstone is dominating the private credit market. High yields.", CreatedOn = new DateTime(2026, 4, 6) },
     new Comment { Id = 50, StockId = 49, Title = "Handset Recovery", Content = "Premium smartphone market is rebounding, helping Qualcomm's bottom line.", CreatedOn = new DateTime(2026, 3, 20) },
     new Comment { Id = 51, StockId = 2, Title = "VR/AR Doubt", Content = "Vision Pro is a tech marvel, but who is actually buying it for $3500?", CreatedOn = new DateTime(2026, 4, 8) },
     new Comment { Id = 52, StockId = 4, Title = "Enterprise Stickiness", Content = "Once a company uses Teams and Excel, they never leave. Wide moat.", CreatedOn = new DateTime(2026, 4, 2) },
     new Comment { Id = 53, StockId = 5, Title = "Advertising Growth", Content = "Amazon's ad business is growing faster than Google's. High margin.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 54, StockId = 18, Title = "Litigation Risks", Content = "J&J still has the talc powder lawsuits hanging over them. Risky.", CreatedOn = new DateTime(2026, 3, 5) },
     new Comment { Id = 55, StockId = 30, Title = "Snack Power", Content = "Pepsi is more of a snack company than a soda company now. I love it.", CreatedOn = new DateTime(2026, 3, 12) },
     new Comment { Id = 56, StockId = 29, Title = "Consumer Staple", Content = "P&G has 60 years of dividend increases. Hard to beat that record.", CreatedOn = new DateTime(2026, 3, 1) },
     new Comment { Id = 57, StockId = 36, Title = "Oncology Lead", Content = "AstraZeneca is the leader in targeted cancer treatments. Huge moat.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 58, StockId = 43, Title = "Hybrid Cloud", Content = "IBM is boring, but it pays a great dividend and the cloud is stable.", CreatedOn = new DateTime(2026, 2, 15) },
     new Comment { Id = 59, StockId = 50, Title = "MedTech Play", Content = "Abbott's Freestyle Libre is the gold standard for glucose monitoring.", CreatedOn = new DateTime(2026, 4, 5) },
     new Comment { Id = 60, StockId = 1, Title = "Margin Expansion", Content = "Gross margins at 75% for a hardware company? Simply unheard of.", CreatedOn = new DateTime(2026, 4, 11) },
     new Comment { Id = 61, StockId = 17, Title = "Gaming Regulation", Content = "Tencent is finally seeing the regulatory environment ease in China.", CreatedOn = new DateTime(2026, 3, 22) },
     new Comment { Id = 62, StockId = 28, Title = "Net Interest Margin", Content = "BAC is the most rate-sensitive big bank. If rates drop, they suffer.", CreatedOn = new DateTime(2026, 4, 3) },
     new Comment { Id = 63, StockId = 27, Title = "Humira Cliff", Content = "AbbVie is handling the loss of patent protection better than expected.", CreatedOn = new DateTime(2026, 3, 18) },
     new Comment { Id = 64, StockId = 13, Title = "Fortress Balance Sheet", Content = "Dimon is the best CEO in banking. Period.", CreatedOn = new DateTime(2026, 4, 1) },
     new Comment { Id = 65, StockId = 7, Title = "VMware Synergy", Content = "The VMware integration into Broadcom is finally yielding efficiency.", CreatedOn = new DateTime(2026, 3, 30) },
     new Comment { Id = 66, StockId = 3, Title = "YouTube Shorts", Content = "Shorts is finally monetizing well enough to compete with TikTok.", CreatedOn = new DateTime(2026, 4, 9) },
     new Comment { Id = 67, StockId = 22, Title = "Data Center AI", Content = "AMD's MI300X is the only real alternative to H100s right now.", CreatedOn = new DateTime(2026, 4, 7) },
     new Comment { Id = 68, StockId = 38, Title = "Commercial Growth", Content = "PLTR isn't just for the government anymore. Commercial is exploding.", CreatedOn = new DateTime(2026, 4, 10) },
     new Comment { Id = 69, StockId = 9, Title = "Robotaxi Event", Content = "Everything depends on the August reveal. Pure speculation till then.", CreatedOn = new DateTime(2026, 4, 11) },
     new Comment { Id = 70, StockId = 2, Title = "Buyback Machine", Content = "Another $100B in buybacks. Apple is a financial engineering masterpiece.", CreatedOn = new DateTime(2026, 4, 11) }
 );


        }
    }
}
using Microsoft.EntityFrameworkCore;
using StockApplicationApi.Models;

namespace StockApplicationApi.Database
{
    /// <summary>
    /// Runtime seeder for volume data (comments).
    /// Idempotent: safe to call on every application startup.
    /// Does NOT run inside migrations — runs after MigrateAsync().
    /// </summary>
    public static class DataSeeder
    {
        /// <summary>
        /// Seeds comments for every stock that doesn't have any yet.
        /// If the Comments table already has rows, this is a no-op.
        /// </summary>
        public static async Task SeedCommentsAsync(
            AppDbContext db,
            int commentsPerStock = 4,
            int randomSeed = 42,
            CancellationToken ct = default)
        {
            // ─── Guard 1: Idempotency ─────────────────────────────
            // If any comments exist, assume seeding already happened.
            if (await db.Comments.AnyAsync(ct))
                return;

            // ─── Guard 2: Need stocks first ───────────────────────
            var stockIds = await db.Stocks
                .OrderBy(s => s.Id)
                .Select(s => s.Id)
                .ToListAsync(ct);

            if (stockIds.Count == 0)
                return;

            // ─── Setup ─────────────────────────────────────────────
            var createdOnBase = new DateTime(2026, 5, 27, 0, 0, 0, DateTimeKind.Utc);
            var random = new Random(randomSeed);

            var titles = new[]
            {
                "Strong Buy", "Long-term Hold", "Overvalued?", "Dip Buyer", "Cautious",
                "Bullish", "Bearish", "Rate Sensitivity", "Margin Watch", "Dividend Play"
            };

            var contents = new[]
            {
                "Demand continues to outpace supply, and management keeps raising guidance.",
                "Valuation is stretched but the growth story remains intact for now.",
                "Margins are compressing, watching next quarter closely before adding.",
                "Every pullback has been a buying opportunity for long-term holders.",
                "Macro headwinds could pressure results, staying on the sidelines.",
                "Balance sheet is fortress-like, gives management huge flexibility.",
                "Free cash flow yield is attractive relative to peers in the sector.",
                "Competitive dynamics are shifting, need to see execution improve.",
                "This name is a core holding for me across multiple portfolios.",
                "Insider activity has been net positive over the last two quarters."
            };

            // ─── Batch insert (memory-safe) ────────────────────────
            const int batchSize = 1000;
            var batch = new List<Comment>(batchSize);

            foreach (var stockId in stockIds)
            {
                for (int i = 0; i < commentsPerStock; i++)
                {
                    int titleIndex = (stockId + i) % titles.Length;
                    int contentIndex = (stockId * 3 + i) % contents.Length;

                    batch.Add(new Comment
                    {
                        // NOTE: no Id set — DB identity assigns it
                        Title = titles[titleIndex],
                        Content = contents[contentIndex],
                        CreatedOn = createdOnBase
                            .AddDays(-random.Next(0, 90))
                            .AddHours(-random.Next(0, 24))
                            .AddMinutes(-random.Next(0, 60)),
                        StockId = stockId,
                        AppUserId = null
                    });

                    if (batch.Count >= batchSize)
                    {
                        db.Comments.AddRange(batch);
                        await db.SaveChangesAsync(ct);
                        db.ChangeTracker.Clear();   // prevents memory bloat
                        batch.Clear();
                    }
                }
            }

            // Flush remainder
            if (batch.Count > 0)
            {
                db.Comments.AddRange(batch);
                await db.SaveChangesAsync(ct);
            }
        }
    }
}
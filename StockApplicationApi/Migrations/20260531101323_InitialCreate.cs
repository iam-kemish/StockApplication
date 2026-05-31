using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Purchase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "text", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StockId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Nvidia", "Semiconductors", 0.16m, 4300000000000L, 188.60m, "NVDA" },
                    { 2, "Apple Inc", "Technology", 0.24m, 3800000000000L, 260.45m, "AAPL" },
                    { 3, "Alphabet", "Technology", 0.00m, 3700000000000L, 315.70m, "GOOGL" },
                    { 4, "Microsoft", "Technology", 0.68m, 2800000000000L, 370.80m, "MSFT" },
                    { 5, "Amazon", "E-Commerce", 0.00m, 2600000000000L, 238.40m, "AMZN" },
                    { 6, "TSMC", "Semiconductors", 1.20m, 1900000000000L, 370.60m, "TSM" },
                    { 7, "Broadcom", "Semiconductors", 2.10m, 1800000000000L, 371.50m, "AVGO" },
                    { 8, "Meta Platforms", "Social Media", 0.50m, 1600000000000L, 629.80m, "META" },
                    { 9, "Tesla", "Automotive", 0.00m, 1300000000000L, 348.90m, "TSLA" },
                    { 10, "Berkshire Hathaway", "Financials", 0.00m, 1030000000000L, 479.90m, "BRK-B" },
                    { 11, "Walmart", "Retail", 0.80m, 1010000000000L, 126.70m, "WMT" },
                    { 12, "Eli Lilly", "Healthcare", 1.30m, 887000000000L, 939.40m, "LLY" },
                    { 13, "JPMorgan Chase", "Financials", 1.15m, 835000000000L, 309.80m, "JPM" },
                    { 14, "Visa", "Financials", 0.52m, 586000000000L, 304.30m, "V" },
                    { 15, "Exxon Mobil", "Energy", 0.95m, 633000000000L, 152.50m, "XOM" },
                    { 16, "ASML Holding", "Semiconductors", 1.75m, 580000000000L, 1478.00m, "ASML" },
                    { 17, "Tencent", "Technology", 0.40m, 578000000000L, 63.90m, "TCEHY" },
                    { 18, "Johnson & Johnson", "Healthcare", 1.19m, 574000000000L, 238.40m, "JNJ" },
                    { 19, "Mastercard", "Financials", 0.66m, 445000000000L, 498.60m, "MA" },
                    { 20, "Costco", "Retail", 1.02m, 443000000000L, 998.40m, "COST" },
                    { 21, "Netflix", "Entertainment", 0.00m, 436000000000L, 103.00m, "NFLX" },
                    { 22, "AMD", "Semiconductors", 0.00m, 399000000000L, 245.00m, "AMD" },
                    { 23, "Oracle", "Software", 0.40m, 397000000000L, 138.00m, "ORCL" },
                    { 24, "Chevron", "Energy", 1.51m, 375000000000L, 188.50m, "CVX" },
                    { 25, "Home Depot", "Retail", 2.25m, 335000000000L, 337.30m, "HD" },
                    { 26, "Coca-Cola", "Beverages", 0.48m, 333000000000L, 77.40m, "KO" },
                    { 27, "AbbVie", "Healthcare", 1.55m, 367000000000L, 207.90m, "ABBV" },
                    { 28, "Bank of America", "Financials", 0.24m, 377000000000L, 52.50m, "BAC" },
                    { 29, "Procter & Gamble", "Consumer Goods", 0.94m, 339000000000L, 145.10m, "PG" },
                    { 30, "PepsiCo", "Beverages", 1.26m, 231000000000L, 168.20m, "PEP" },
                    { 31, "Salesforce", "Software", 0.40m, 285000000000L, 295.40m, "CRM" },
                    { 32, "Adobe", "Software", 0.00m, 262000000000L, 585.10m, "ADBE" },
                    { 33, "Nike", "Apparel", 0.37m, 153000000000L, 101.50m, "NKE" },
                    { 34, "Disney", "Entertainment", 0.30m, 205000000000L, 112.80m, "DIS" },
                    { 35, "Toyota", "Automotive", 0.85m, 274000000000L, 210.60m, "TM" },
                    { 36, "AstraZeneca", "Healthcare", 1.90m, 316000000000L, 204.00m, "AZN" },
                    { 37, "Intel", "Semiconductors", 0.12m, 313000000000L, 62.30m, "INTC" },
                    { 38, "Palantir", "Software", 0.00m, 306000000000L, 128.00m, "PLTR" },
                    { 39, "Alibaba", "E-Commerce", 0.00m, 304000000000L, 127.30m, "BABA" },
                    { 40, "Pfizer", "Healthcare", 0.42m, 161000000000L, 28.50m, "PFE" },
                    { 41, "Caterpillar", "Industrials", 1.30m, 370000000000L, 790.60m, "CAT" },
                    { 42, "Cisco", "Technology", 0.40m, 324000000000L, 82.20m, "CSCO" },
                    { 43, "IBM", "Technology", 1.66m, 170000000000L, 185.30m, "IBM" },
                    { 44, "Goldman Sachs", "Financials", 2.75m, 269000000000L, 907.80m, "GS" },
                    { 45, "McDonald's", "Restaurants", 1.67m, 210000000000L, 290.40m, "MCD" },
                    { 46, "Starbucks", "Restaurants", 0.57m, 105000000000L, 92.50m, "SBUX" },
                    { 47, "UPS", "Logistics", 1.63m, 125000000000L, 145.80m, "UPS" },
                    { 48, "Blackstone", "Financials", 0.82m, 158000000000L, 130.20m, "BX" },
                    { 49, "Qualcomm", "Semiconductors", 0.80m, 190000000000L, 170.50m, "QCOM" },
                    { 50, "Abbott Labs", "Healthcare", 0.55m, 201000000000L, 115.40m, "ABT" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AppUserId", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, null, "Blackwell GPU demand is insane, this stock has legs.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Strong Buy" },
                    { 2, null, "AI infrastructure spending keeps benefiting Nvidia. Not selling.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Long-term Hold" },
                    { 3, null, "P/E is getting stretched. I trimmed my position last week.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Overvalued?" },
                    { 4, null, "Every pullback on NVDA has been a buying opportunity so far.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Dip Buyer" },
                    { 5, null, "Services revenue is great but hardware growth is slowing.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Cautious" },
                    { 6, null, "Apple Intelligence could be a huge catalyst in 2025.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Bullish on AI" },
                    { 7, null, "AI search could cannibalize their core business long-term.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Ad Revenue Concern" },
                    { 8, null, "Copilot integration across Office 365 is a massive moat.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 4, "AI Leader" },
                    { 9, null, "Azure growth numbers keep impressing every quarter.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Azure Growth" },
                    { 10, null, "Not flashy but MSFT keeps quietly raising its dividend.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Solid Dividend" },
                    { 11, null, "AWS margins are expanding nicely. Best cloud play out there.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 5, "AWS Dominance" },
                    { 12, null, "Cost-cutting in logistics is finally showing up in earnings.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 5, "Retail Efficiency" },
                    { 13, null, "Every advanced chip runs through TSMC. Truly irreplaceable.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Essential Monopoly" },
                    { 14, null, "Taiwan tensions are a real risk factor to keep watching.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Geopolitical Risk" },
                    { 15, null, "US fab expansion reduces geopolitical risk over time.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Arizona Expansion" },
                    { 16, null, "TSMC keeps raising wafer prices and customers just pay it.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Pricing Power" },
                    { 17, null, "AVGO's custom ASIC business for hyperscalers is quietly booming.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 7, "Custom AI Chips" },
                    { 18, null, "Their ad targeting is best-in-class and only getting stronger.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 8, "Ad Machine" },
                    { 19, null, "Metaverse spending is still a massive cash burn with no end in sight.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 8, "Reality Labs Drain" },
                    { 20, null, "Open-sourcing Llama is a smart long-term moat-building play.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 8, "Llama Strategy" },
                    { 21, null, "Hard to justify this price on auto earnings alone.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 9, "Valuation Stretched" },
                    { 22, null, "Full Self-Driving could completely re-rate this stock if it works.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 9, "FSD Potential" },
                    { 23, null, "Buffett's cash pile gives him incredible flexibility right now.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 10, "Safe Haven" },
                    { 24, null, "Walmart's grocery dominance is extremely hard to compete with.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 11, "Retail Powerhouse" },
                    { 25, null, "Walmart+ and online growth are finally clicking into place.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 11, "E-Commerce Pivot" },
                    { 26, null, "Mounjaro and Zepbound demand far outpaces supply right now.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 12, "GLP-1 Leader" },
                    { 27, null, "The premium is massive but the pipeline arguably justifies it.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 12, "High Valuation" },
                    { 28, null, "Manufacturing capacity is the only thing limiting LLY growth.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 12, "Supply Ramp" },
                    { 29, null, "The total addressable market for obesity drugs is enormous.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 12, "Obesity Market" },
                    { 30, null, "Dimon keeps executing flawlessly in any rate environment.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 13, "Best Bank" },
                    { 31, null, "NII may compress if the Fed cuts rates faster than expected.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 13, "Rate Sensitivity" },
                    { 32, null, "JPM always seems to come out of downturns stronger than peers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 13, "Fortress Balance Sheet" },
                    { 33, null, "Visa's margins and free cash flow are simply phenomenal.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 14, "Cash Flow Beast" },
                    { 34, null, "XOM's dividend history is about as reliable as it gets.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 15, "Dividend Rock" },
                    { 35, null, "Pioneer acquisition is boosting Permian production nicely.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 15, "Pioneer Synergies" },
                    { 36, null, "ASML is literally the only company making EUV lithography machines.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 16, "EUV Monopoly" },
                    { 37, null, "Export restrictions to China are a real headwind worth watching.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 16, "China Export Risk" },
                    { 38, null, "Next-gen High NA EUV tools will keep ASML ahead for a decade.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 16, "High NA EUV" },
                    { 39, null, "The order backlog is enormous — revenue visibility is exceptional.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 16, "Backlog Monster" },
                    { 40, null, "Chinese tech regulation remains an unpredictable ongoing concern.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 17, "Regulatory Overhang" },
                    { 41, null, "JNJ is a classic defensive hold with steady reliable dividends.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 18, "Defensive Pick" },
                    { 42, null, "Post-Kenvue spinoff JNJ is sharper and more focused than ever.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 18, "MedTech Focus" },
                    { 43, null, "Mastercard benefits every single time a new market goes cashless.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 19, "Global Expansion" },
                    { 44, null, "Travel recovery has been a huge tailwind for Mastercard.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 19, "Cross-border Revenue" },
                    { 45, null, "MA is positioning itself well even in a crypto payments world.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 19, "Crypto Hedge" },
                    { 46, null, "The 90%+ membership renewal rate is one of retail's best moats.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 20, "Membership Model" },
                    { 47, null, "Paid sharing drove subscriber growth well beyond expectations.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 21, "Password Crackdown Win" },
                    { 48, null, "The ad-supported tier is a whole new revenue stream with big upside.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 21, "Ad Tier Growth" },
                    { 49, null, "MI300X is gaining real traction against Nvidia in AI workloads.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 22, "Data Center Push" },
                    { 50, null, "Gaming GPU and laptop CPU cycles look set to recover this year.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 22, "PC Recovery" },
                    { 51, null, "EPYC server CPUs keep taking share from Intel in data centers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 22, "EPYC Dominance" },
                    { 52, null, "AMD's turnaround under Lisa Su is one of tech's best CEO stories.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 22, "Lisa Su Effect" },
                    { 53, null, "OCI is winning large AI training contracts no one expected.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 23, "Cloud Acceleration" },
                    { 54, null, "The Hess acquisition brings great Guyana deepwater assets onboard.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 24, "Hess Deal" },
                    { 55, null, "CVX's buyback program is among the best in the energy sector.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 24, "Shareholder Returns" },
                    { 56, null, "Everything hinges on crude prices — keep an eye on OPEC+ decisions.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 24, "Oil Price Watch" },
                    { 57, null, "HD will benefit big when mortgage rates eventually come down.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 25, "Housing Cycle" },
                    { 58, null, "The Pro contractor segment is a high-margin and growing revenue driver.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 25, "Pro Segment" },
                    { 59, null, "KO has raised its dividend for over 60 consecutive years. Legendary.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 26, "Dividend Aristocrat" },
                    { 60, null, "Skyrizi and Rinvoq are more than compensating for Humira losses.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 27, "Post-Humira Transition" },
                    { 61, null, "ABBV pays a strong dividend while still actively growing its pipeline.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 27, "High Dividend Yield" },
                    { 62, null, "Recent bolt-on acquisitions show management is thinking long-term.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 27, "Acquisition Strategy" },
                    { 63, null, "BAC is highly leveraged to interest rates — watch the Fed closely.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 28, "Rate Sensitivity" },
                    { 64, null, "Massive consumer deposit base is a durable competitive advantage.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 28, "Consumer Banking" },
                    { 65, null, "PG is boring in the best possible way. Reliable decade after decade.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 29, "Steady Compounder" },
                    { 66, null, "Frito-Lay alone is arguably worth the entire investment in PepsiCo.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 30, "Snacks Powerhouse" },
                    { 67, null, "Beverage volume softness is worth monitoring over the next few quarters.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 30, "Volume Pressure" },
                    { 68, null, "Emerging market expansion is a quiet but steady growth engine.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 30, "International Growth" },
                    { 69, null, "PEP has raised its dividend for over 50 years. Hard to ignore.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 30, "Dividend Growth" },
                    { 70, null, "Agentforce could become a major new revenue stream for Salesforce.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 31, "AI Agents" },
                    { 71, null, "Salesforce is finally delivering the profitability investors wanted.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 31, "Margin Expansion" },
                    { 72, null, "Generative AI tools could commoditize parts of Adobe's creative suite.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 32, "AI Disruption Risk" },
                    { 73, null, "New leadership needs to reinvigorate wholesale channels and product innovation.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 33, "Brand Turnaround" },
                    { 74, null, "Any recovery in China consumer spending would significantly help NKE.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 33, "China Recovery" },
                    { 75, null, "NKE is trading at a much more reasonable valuation than it was two years ago.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 33, "Valuation Reset" },
                    { 76, null, "Disney+ finally turning profitable is a major long-awaited milestone.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 34, "Streaming Profitability" },
                    { 77, null, "Theme park demand has stayed far stronger than many analysts expected.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 34, "Parks Resilience" },
                    { 78, null, "Toyota's hybrid lineup keeps outselling pure EVs in most global markets.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 35, "Hybrid Leader" },
                    { 79, null, "AZN's cancer drug portfolio is one of the very best in all of pharma.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 36, "Oncology Pipeline" },
                    { 80, null, "AZN has meaningful China revenue which adds real political risk.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 36, "China Exposure" },
                    { 81, null, "Rare disease acquisitions could add significant future revenue streams.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 36, "Rare Disease Bets" },
                    { 82, null, "Tagrisso remains a dominant lung cancer treatment with strong revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 36, "Tagrisso Growth" },
                    { 83, null, "Intel Foundry is a massive multi-year bet that will take time to play out.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 37, "Foundry Bet" },
                    { 84, null, "AMD and Arm-based chips keep eating into Intel's data center share.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 37, "Market Share Loss" },
                    { 85, null, "Palantir's AI Platform is gaining strong momentum in enterprise.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 38, "AIP Traction" },
                    { 86, null, "PLTR's valuation is extremely stretched relative to current revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 38, "Valuation Debate" },
                    { 87, null, "Defense and intelligence contracts provide very stable recurring revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 38, "Government Contracts" },
                    { 88, null, "Trading at low multiples makes BABA tempting for patient value investors.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 39, "Cheap Valuation" },
                    { 89, null, "Pfizer is working hard to replace the massive lost COVID vaccine revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 40, "Post-COVID Reset" },
                    { 90, null, "Oncology-focused acquisitions could meaningfully restock the pipeline.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 40, "Pipeline Watch" },
                    { 91, null, "CAT benefits directly from global infrastructure and construction spending.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 41, "Infrastructure Boom" },
                    { 92, null, "Mining equipment demand remains strong with commodity prices elevated.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 41, "Mining Demand" },
                    { 93, null, "CAT's aftermarket parts and services segment has incredible margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 41, "Services Growth" },
                    { 94, null, "Order backlogs remain healthy pointing to strong revenue ahead.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 41, "Backlog Strength" },
                    { 95, null, "AI data centers need massive networking upgrades — Cisco is well placed.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 42, "AI Networking" },
                    { 96, null, "IBM's Red Hat continues to be a solid enterprise hybrid cloud play.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 43, "Hybrid Cloud Focus" },
                    { 97, null, "watsonx is IBM's enterprise AI bet and early adoption signs are decent.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 43, "AI Consulting" },
                    { 98, null, "IBM keeps paying a reliable dividend while quietly modernizing itself.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 43, "Steady Dividend" },
                    { 99, null, "Investment banking deal flow is finally picking up after a tough cycle.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 44, "IB Recovery" },
                    { 100, null, "Pulling back from consumer banking was clearly the right strategic call.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 44, "Consumer Exit" },
                    { 101, null, "The asset-light franchise model generates incredibly consistent cash flow.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 45, "Franchise Model" },
                    { 102, null, "New CEO Brian Niccol needs to fix both traffic trends and brand perception.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 46, "Turnaround Watch" },
                    { 103, null, "China comp sales remain under heavy pressure from aggressive local rivals.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 46, "China Weakness" },
                    { 104, null, "Cutting back the menu complexity is a smart operational move.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 46, "Menu Simplification" },
                    { 105, null, "Starbucks Rewards membership is a genuinely powerful retention engine.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 46, "Loyalty Program" },
                    { 106, null, "Parcel volume is slowly recovering as e-commerce spending stabilizes.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 47, "Volume Recovery" },
                    { 107, null, "Amazon building its own logistics network is a serious long-term threat.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 47, "Amazon Risk" },
                    { 108, null, "Blackstone keeps breaking records on assets under management every quarter.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 48, "AUM Growth" },
                    { 109, null, "Arm-based Windows PCs powered by Snapdragon are genuinely gaining ground.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 49, "Snapdragon PC Push" },
                    { 110, null, "Losing Apple as a modem customer was a more significant blow than expected.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 49, "Apple Dependency" },
                    { 111, null, "Automotive chip wins are diversifying QCOM beyond just smartphones.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 49, "Auto Chips" },
                    { 112, null, "FreeStyle Libre dominates the continuous glucose monitoring market globally.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 50, "CGM Leader" },
                    { 113, null, "Abbott's mix of diagnostics, devices and nutrition is impressively balanced.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 50, "Diversified Medtech" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AppUserId",
                table: "RefreshTokens",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

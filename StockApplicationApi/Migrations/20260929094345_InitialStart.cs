using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialStart : Migration
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
                    UsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    { 50, "Abbott Labs", "Healthcare", 0.55m, 201000000000L, 115.40m, "ABT" },
                    { 51, "UnitedHealth Group", "Healthcare", 2.10m, 530000000000L, 580.20m, "UNH" },
                    { 52, "ServiceNow", "Software", 0.00m, 185000000000L, 890.40m, "NOW" },
                    { 53, "GE Aerospace", "Aerospace", 0.28m, 192000000000L, 175.80m, "GE" },
                    { 54, "Applied Materials", "Semiconductors", 0.40m, 172000000000L, 210.30m, "AMAT" },
                    { 55, "Intuitive Surgical", "Healthcare", 0.00m, 164000000000L, 460.50m, "ISRG" },
                    { 56, "Booking Holdings", "Travel", 8.75m, 145000000000L, 4200.00m, "BKNG" },
                    { 57, "Texas Instruments", "Semiconductors", 1.30m, 188000000000L, 205.10m, "TXN" },
                    { 58, "Lam Research", "Semiconductors", 2.30m, 106000000000L, 820.70m, "LRCX" },
                    { 59, "S&P Global", "Financials", 0.91m, 159000000000L, 510.80m, "SPGI" },
                    { 60, "Stryker", "Healthcare", 0.80m, 139000000000L, 365.40m, "SYK" },
                    { 61, "Palo Alto Networks", "Cybersecurity", 0.00m, 112000000000L, 345.90m, "PANW" },
                    { 62, "Arista Networks", "Networking", 0.00m, 102000000000L, 325.00m, "ANET" },
                    { 63, "Micron Technology", "Semiconductors", 0.11m, 144000000000L, 130.40m, "MU" },
                    { 64, "Automatic Data Processing", "Software", 1.40m, 113000000000L, 275.60m, "ADP" },
                    { 65, "TJX Companies", "Retail", 0.38m, 133000000000L, 118.90m, "TJX" },
                    { 66, "Mondelez International", "Consumer Goods", 0.47m, 97000000000L, 72.30m, "MDLZ" },
                    { 67, "Fiserv", "Financials", 0.00m, 105000000000L, 178.50m, "FI" },
                    { 68, "Charles Schwab", "Financials", 0.25m, 124000000000L, 68.40m, "SCHW" },
                    { 69, "Progressive", "Insurance", 0.10m, 144000000000L, 245.80m, "PGR" },
                    { 70, "Uber Technologies", "Transportation", 0.00m, 163000000000L, 78.90m, "UBER" },
                    { 71, "Chubb Limited", "Insurance", 0.91m, 114000000000L, 280.30m, "CB" },
                    { 72, "John Deere", "Industrials", 1.47m, 109000000000L, 395.20m, "DE" },
                    { 73, "Sempra Energy", "Utilities", 0.62m, 53000000000L, 84.50m, "SRE" },
                    { 74, "Marsh McLennan", "Insurance", 0.81m, 111000000000L, 225.10m, "MMC" },
                    { 75, "Regeneron Pharmaceuticals", "Healthcare", 0.00m, 123000000000L, 1150.00m, "REGN" },
                    { 76, "Analog Devices", "Semiconductors", 0.92m, 114000000000L, 230.80m, "ADI" },
                    { 77, "KLA Corporation", "Semiconductors", 1.45m, 109000000000L, 815.40m, "KLAC" },
                    { 78, "Boston Scientific", "Healthcare", 0.00m, 121000000000L, 82.60m, "BSX" },
                    { 79, "Waste Management", "Services", 0.75m, 86000000000L, 215.30m, "WM" },
                    { 80, "Sherwin-Williams", "Materials", 0.71m, 90000000000L, 360.20m, "SHW" },
                    { 81, "HCA Healthcare", "Healthcare", 0.66m, 98000000000L, 380.50m, "HCA" },
                    { 82, "Eaton Corporation", "Industrials", 0.94m, 131000000000L, 330.10m, "ETN" },
                    { 83, "CrowdStrike", "Cybersecurity", 0.00m, 68000000000L, 280.40m, "CRWD" },
                    { 84, "Synopsys", "Software", 0.00m, 89000000000L, 580.90m, "SNPS" },
                    { 85, "Cadence Design Systems", "Software", 0.00m, 78000000000L, 290.10m, "CDNS" },
                    { 86, "Medtronic", "Healthcare", 0.70m, 113000000000L, 88.40m, "MDT" },
                    { 87, "The Cigna Group", "Healthcare", 1.40m, 99000000000L, 350.20m, "CI" },
                    { 88, "Ecolab", "Chemicals", 0.57m, 71000000000L, 250.60m, "ECL" },
                    { 89, "Illinois Tool Works", "Industrials", 1.40m, 78000000000L, 260.80m, "ITW" },
                    { 90, "Parker-Hannifin", "Industrials", 1.63m, 75000000000L, 590.20m, "PH" },
                    { 91, "Moody's Corporation", "Financials", 0.85m, 89000000000L, 490.50m, "MCO" },
                    { 92, "CSX Corporation", "Transportation", 0.12m, 68000000000L, 35.10m, "CSX" },
                    { 93, "Norfolk Southern", "Transportation", 1.35m, 54000000000L, 240.60m, "NSC" },
                    { 94, "FedEx", "Logistics", 1.38m, 70000000000L, 285.30m, "FDX" },
                    { 95, "McKesson Corporation", "Healthcare", 0.71m, 76000000000L, 590.80m, "MCK" },
                    { 96, "O'Reilly Automotive", "Retail", 0.00m, 67000000000L, 1150.00m, "ORLY" },
                    { 97, "AutoZone", "Retail", 0.00m, 52000000000L, 3100.00m, "AZO" },
                    { 98, "Marriott International", "Hospitality", 0.63m, 71000000000L, 250.40m, "MAR" },
                    { 99, "Hilton Worldwide", "Hospitality", 0.15m, 55000000000L, 220.10m, "HLT" },
                    { 100, "Shopify", "E-Commerce", 0.00m, 101000000000L, 78.50m, "SHOP" },
                    { 101, "Block Inc", "Fintech", 0.00m, 42000000000L, 68.20m, "SQ" },
                    { 102, "PayPal", "Fintech", 0.00m, 74000000000L, 72.40m, "PYPL" },
                    { 103, "Coinbase", "Fintech", 0.00m, 54000000000L, 220.10m, "COIN" },
                    { 104, "Spotify", "Entertainment", 0.00m, 68000000000L, 340.60m, "SPOT" },
                    { 105, "Snowflake", "Software", 0.00m, 41000000000L, 125.30m, "SNOW" },
                    { 106, "DataDog", "Software", 0.00m, 39000000000L, 118.40m, "DDOG" },
                    { 107, "Cloudflare", "Cybersecurity", 0.00m, 28000000000L, 82.10m, "NET" },
                    { 108, "Zscaler", "Cybersecurity", 0.00m, 29000000000L, 190.50m, "ZS" },
                    { 109, "Twilio", "Software", 0.00m, 10000000000L, 62.80m, "TWLO" },
                    { 110, "Roku", "Entertainment", 0.00m, 11000000000L, 75.20m, "ROKU" },
                    { 111, "UiPath", "Software", 0.00m, 7500000000L, 13.40m, "PATH" },
                    { 112, "MongoDB", "Software", 0.00m, 20000000000L, 280.90m, "MDB" },
                    { 113, "Roblox", "Gaming", 0.00m, 26000000000L, 42.10m, "RBLX" },
                    { 114, "Unity Software", "Software", 0.00m, 7000000000L, 18.50m, "U" },
                    { 115, "The Trade Desk", "Advertising", 0.00m, 50000000000L, 102.30m, "TTD" },
                    { 116, "AppLovin", "Software", 0.00m, 28000000000L, 85.60m, "APP" },
                    { 117, "Affirm Holdings", "Fintech", 0.00m, 12000000000L, 38.40m, "AFRM" },
                    { 118, "SoFi Technologies", "Fintech", 0.00m, 8800000000L, 8.20m, "SOFI" },
                    { 119, "Robinhood", "Fintech", 0.00m, 19000000000L, 22.40m, "HOOD" },
                    { 120, "Pinterest", "Social Media", 0.00m, 21000000000L, 31.50m, "PINS" },
                    { 121, "Snap Inc", "Social Media", 0.00m, 16000000000L, 9.80m, "SNAP" },
                    { 122, "Lyft Inc", "Transportation", 0.00m, 5000000000L, 12.40m, "LYFT" },
                    { 123, "DoorDash", "Services", 0.00m, 52000000000L, 128.50m, "DASH" },
                    { 124, "Airbnb", "Hospitality", 0.00m, 74000000000L, 118.20m, "ABNB" },
                    { 125, "Zoom Video", "Software", 0.00m, 21000000000L, 68.30m, "ZM" },
                    { 126, "DocuSign", "Software", 0.00m, 12000000000L, 58.10m, "DOCU" },
                    { 127, "Okta Inc", "Cybersecurity", 0.00m, 14000000000L, 82.40m, "OKTA" },
                    { 128, "Elastic NV", "Software", 0.00m, 8200000000L, 78.90m, "ESTC" },
                    { 129, "GitLab", "Software", 0.00m, 8400000000L, 52.30m, "GTLB" },
                    { 130, "Arm Holdings", "Semiconductors", 0.00m, 143000000000L, 138.50m, "ARM" },
                    { 131, "Super Micro Computer", "Hardware", 0.00m, 26000000000L, 450.20m, "SMCI" },
                    { 132, "AST SpaceMobile", "Telecommunications", 0.00m, 7200000000L, 28.40m, "ASTS" },
                    { 133, "Rocket Lab", "Aerospace", 0.00m, 3400000000L, 6.80m, "RKLB" },
                    { 134, "Intuitive Machines", "Aerospace", 0.00m, 750000000L, 5.20m, "LUNR" },
                    { 135, "Joby Aviation", "Aerospace", 0.00m, 3600000000L, 5.10m, "JOBY" },
                    { 136, "Archer Aviation", "Aerospace", 0.00m, 1200000000L, 3.80m, "ACHR" },
                    { 137, "IonQ Inc", "Computing", 0.00m, 1700000000L, 8.10m, "IONQ" },
                    { 138, "Rigetti Computing", "Computing", 0.00m, 220000000L, 1.15m, "RGTI" },
                    { 139, "SoundHound AI", "Software", 0.00m, 1800000000L, 5.30m, "SOUN" },
                    { 140, "BigBear.ai", "Software", 0.00m, 450000000L, 1.85m, "BBAI" },
                    { 141, "C3.ai", "Software", 0.00m, 3000000000L, 24.10m, "AI" },
                    { 142, "SentinelOne", "Cybersecurity", 0.00m, 7100000000L, 22.80m, "S" },
                    { 143, "Tenable Holdings", "Cybersecurity", 0.00m, 4900000000L, 42.10m, "TENB" },
                    { 144, "Varonis Systems", "Cybersecurity", 0.00m, 6000000000L, 54.30m, "VRNS" },
                    { 145, "Rapid7", "Cybersecurity", 0.00m, 2400000000L, 38.20m, "RPD" },
                    { 146, "Bill Holdings", "Fintech", 0.00m, 5400000000L, 52.40m, "BILL" },
                    { 147, "Toast Inc", "Software", 0.00m, 14800000000L, 26.80m, "TOST" },
                    { 148, "Grab Holdings", "Transportation", 0.00m, 13500000000L, 3.45m, "GRAB" },
                    { 149, "Sea Limited", "E-Commerce", 0.00m, 46000000000L, 81.20m, "SE" },
                    { 150, "Wells Fargo", "Financials", 0.35m, 195000000000L, 56.30m, "WFC" },
                    { 151, "Citigroup", "Financials", 0.53m, 116000000000L, 61.20m, "C" },
                    { 152, "Morgan Stanley", "Financials", 0.85m, 160000000000L, 98.40m, "MS" },
                    { 153, "US Bancorp", "Financials", 0.49m, 68000000000L, 44.10m, "USB" },
                    { 154, "PNC Financial", "Financials", 1.55m, 65000000000L, 165.20m, "PNC" },
                    { 155, "Truist Financial", "Financials", 0.52m, 57000000000L, 42.80m, "TFC" },
                    { 156, "BNY Mellon", "Financials", 0.42m, 48000000000L, 64.30m, "BK" },
                    { 157, "State Street", "Financials", 0.69m, 25000000000L, 84.10m, "STT" },
                    { 158, "Fifth Third Bancorp", "Financials", 0.35m, 26000000000L, 38.50m, "FITB" },
                    { 159, "KeyCorp", "Financials", 0.20m, 15000000000L, 15.80m, "KEY" },
                    { 160, "Citizens Financial", "Financials", 0.42m, 17000000000L, 36.20m, "CFG" },
                    { 161, "Regions Financial", "Financials", 0.24m, 19000000000L, 21.40m, "RF" },
                    { 162, "Huntington Bancshares", "Financials", 0.15m, 21000000000L, 14.60m, "HBAN" },
                    { 163, "American International", "Insurance", 0.36m, 49000000000L, 74.20m, "AIG" },
                    { 164, "MetLife", "Insurance", 0.52m, 52000000000L, 72.80m, "MET" },
                    { 165, "Prudential Financial", "Insurance", 1.30m, 43000000000L, 118.50m, "PRU" },
                    { 166, "Allstate", "Insurance", 0.92m, 48000000000L, 182.40m, "ALL" },
                    { 167, "The Travelers Companies", "Insurance", 1.05m, 52000000000L, 230.10m, "TRV" },
                    { 168, "The Hartford", "Insurance", 0.47m, 31000000000L, 105.30m, "HIG" },
                    { 169, "Aflac", "Insurance", 0.50m, 53000000000L, 92.40m, "AFL" },
                    { 170, "Ameriprise Financial", "Financials", 1.48m, 43000000000L, 440.80m, "AMP" },
                    { 171, "Raymond James", "Financials", 0.45m, 25000000000L, 122.50m, "RJF" },
                    { 172, "MSCI Inc", "Financials", 1.60m, 44000000000L, 560.20m, "MSCI" },
                    { 173, "Cboe Global Markets", "Financials", 0.55m, 21000000000L, 205.40m, "CBOE" },
                    { 174, "CME Group", "Financials", 1.15m, 78000000000L, 218.90m, "CME" },
                    { 175, "Intercontinental Exchange", "Financials", 0.45m, 89000000000L, 155.30m, "ICE" },
                    { 176, "Nasdaq Inc", "Financials", 0.24m, 39000000000L, 68.20m, "NDAQ" },
                    { 177, "Aon plc", "Insurance", 0.67m, 74000000000L, 340.50m, "AON" },
                    { 178, "Willis Towers Watson", "Insurance", 0.88m, 28000000000L, 285.10m, "WTW" },
                    { 179, "AT&T", "Telecommunications", 0.27m, 139000000000L, 19.40m, "T" },
                    { 180, "Verizon", "Telecommunications", 0.66m, 175000000000L, 41.80m, "VZ" },
                    { 181, "T-Mobile US", "Telecommunications", 0.65m, 228000000000L, 195.20m, "TMUS" },
                    { 182, "Comcast", "Entertainment", 0.31m, 153000000000L, 39.50m, "CMCSA" },
                    { 183, "Charter Communications", "Telecommunications", 0.00m, 46000000000L, 320.40m, "CHTR" },
                    { 184, "Alliant Energy", "Utilities", 0.48m, 14000000000L, 58.20m, "LNT" },
                    { 185, "American Electric Power", "Utilities", 0.88m, 51000000000L, 98.10m, "AEP" },
                    { 186, "Dominion Energy", "Utilities", 0.66m, 47000000000L, 56.40m, "D" },
                    { 187, "Duke Energy", "Utilities", 1.02m, 86000000000L, 112.30m, "DUK" },
                    { 188, "The Southern Company", "Utilities", 0.72m, 96000000000L, 88.50m, "SO" },
                    { 189, "NextEra Energy", "Utilities", 0.51m, 167000000000L, 81.40m, "NEE" },
                    { 190, "Exelon", "Utilities", 0.38m, 39000000000L, 39.80m, "EXC" },
                    { 191, "Xcel Energy", "Utilities", 0.54m, 35000000000L, 64.20m, "XEL" },
                    { 192, "Consolidated Edison", "Utilities", 0.83m, 34000000000L, 98.60m, "ED" },
                    { 193, "WEC Energy Group", "Utilities", 0.83m, 28000000000L, 89.10m, "WEC" },
                    { 194, "Edison International", "Utilities", 0.78m, 32000000000L, 84.50m, "EIX" },
                    { 195, "American Water Works", "Utilities", 0.76m, 27000000000L, 138.20m, "AWK" },
                    { 196, "Ameren", "Utilities", 0.67m, 21000000000L, 82.40m, "AEE" },
                    { 197, "CMS Energy", "Utilities", 0.51m, 20000000000L, 68.90m, "CMS" },
                    { 198, "DTE Energy", "Utilities", 1.02m, 25000000000L, 125.10m, "DTE" },
                    { 199, "Schlumberger", "Energy", 0.27m, 64000000000L, 45.20m, "SLB" },
                    { 200, "Halliburton", "Energy", 0.17m, 28000000000L, 32.10m, "HAL" },
                    { 201, "Baker Hughes", "Energy", 0.21m, 35000000000L, 35.80m, "BKR" },
                    { 202, "EOG Resources", "Energy", 0.91m, 72000000000L, 125.40m, "EOG" },
                    { 203, "ConocoPhillips", "Energy", 0.58m, 131000000000L, 112.80m, "COP" },
                    { 204, "Pioneer Natural Resources", "Energy", 1.10m, 62000000000L, 268.00m, "PXD" },
                    { 205, "Occidental Petroleum", "Energy", 0.22m, 50000000000L, 56.30m, "OXY" },
                    { 206, "Marathon Petroleum", "Energy", 0.82m, 59000000000L, 172.50m, "MPC" },
                    { 207, "Valero Energy", "Energy", 1.07m, 48000000000L, 148.90m, "VLO" },
                    { 208, "Phillips 66", "Energy", 1.15m, 58000000000L, 138.20m, "PSX" },
                    { 209, "Hess Corporation", "Energy", 0.43m, 43000000000L, 142.10m, "HES" },
                    { 210, "Devon Energy", "Energy", 0.35m, 26000000000L, 41.50m, "DVN" },
                    { 211, "Diamondback Energy", "Energy", 0.90m, 33000000000L, 185.30m, "FANG" },
                    { 212, "Kinder Morgan", "Energy", 0.28m, 48000000000L, 21.80m, "KMI" },
                    { 213, "Williams Companies", "Energy", 0.47m, 53000000000L, 44.20m, "WMB" },
                    { 214, "ONEOK", "Energy", 0.99m, 51000000000L, 88.50m, "OKE" },
                    { 215, "Targa Resources", "Energy", 0.75m, 30000000000L, 135.10m, "TRGP" },
                    { 216, "Freeport-McMoRan", "Materials", 0.15m, 69000000000L, 48.20m, "FCX" },
                    { 217, "Newmont Corporation", "Materials", 0.25m, 56000000000L, 48.90m, "NEM" },
                    { 218, "Southern Copper", "Materials", 0.80m, 83000000000L, 108.50m, "SCCO" },
                    { 219, "Air Products", "Chemicals", 1.77m, 63000000000L, 285.40m, "APD" },
                    { 220, "DuPont de Nemours", "Chemicals", 0.38m, 34000000000L, 82.10m, "DD" },
                    { 221, "Dow Inc", "Chemicals", 0.70m, 36000000000L, 52.30m, "DOW" },
                    { 222, "PPG Industries", "Chemicals", 0.68m, 31000000000L, 132.80m, "PPG" },
                    { 223, "Albemarle", "Chemicals", 0.40m, 10800000000L, 92.50m, "ALB" },
                    { 224, "Nucor Corporation", "Materials", 0.54m, 37000000000L, 158.40m, "NUE" },
                    { 225, "Steel Dynamics", "Materials", 0.46m, 19000000000L, 125.10m, "STLD" },
                    { 226, "Vulcan Materials", "Materials", 0.46m, 33000000000L, 255.80m, "VMC" },
                    { 227, "Martin Marietta", "Materials", 0.74m, 35000000000L, 580.20m, "MLM" },
                    { 228, "Honeywell", "Industrials", 1.08m, 133000000000L, 205.30m, "HON" },
                    { 229, "3M Company", "Industrials", 0.70m, 70000000000L, 128.50m, "MMM" },
                    { 230, "RTX Corporation", "Aerospace", 0.63m, 159000000000L, 120.10m, "RTX" },
                    { 231, "Lockheed Martin", "Aerospace", 3.15m, 134000000000L, 560.40m, "LMT" },
                    { 232, "Boeing", "Aerospace", 0.00m, 99000000000L, 162.30m, "BA" },
                    { 233, "Northrop Grumman", "Aerospace", 2.06m, 76000000000L, 520.80m, "NOC" },
                    { 234, "General Dynamics", "Aerospace", 1.42m, 82000000000L, 302.50m, "GD" },
                    { 235, "TransDigm Group", "Aerospace", 0.00m, 74000000000L, 1320.00m, "TDG" },
                    { 236, "Axon Enterprise", "Aerospace", 0.00m, 28000000000L, 380.50m, "AXON" },
                    { 237, "Emerson Electric", "Industrials", 0.52m, 62000000000L, 108.20m, "EMR" },
                    { 238, "Rockwell Automation", "Industrials", 1.25m, 31000000000L, 275.40m, "ROK" },
                    { 239, "AMETEK", "Industrials", 0.28m, 39000000000L, 172.10m, "AME" },
                    { 240, "Trane Technologies", "Industrials", 0.84m, 85000000000L, 380.20m, "TT" },
                    { 241, "Carrier Global", "Industrials", 0.19m, 61000000000L, 68.50m, "CARR" },
                    { 242, "Otis Worldwide", "Industrials", 0.39m, 39000000000L, 98.20m, "OTIS" },
                    { 243, "Fastenal", "Industrials", 0.39m, 40000000000L, 70.40m, "FAST" },
                    { 244, "WW Grainger", "Industrials", 2.05m, 48000000000L, 980.50m, "GWW" },
                    { 245, "Canadian Pacific Kansas", "Transportation", 0.19m, 76000000000L, 82.30m, "CP" },
                    { 246, "Canadian National Railway", "Transportation", 0.84m, 74000000000L, 118.50m, "CNI" },
                    { 247, "Johnson Controls", "Industrials", 0.37m, 48000000000L, 72.60m, "JCI" },
                    { 248, "Quanta Services", "Industrials", 0.09m, 48000000000L, 328.40m, "PWR" },
                    { 249, "United Rentals", "Industrials", 1.63m, 51000000000L, 780.20m, "URI" },
                    { 250, "PACCAR Inc", "Industrials", 0.27m, 57000000000L, 108.50m, "PCAR" },
                    { 251, "SPDR S&P 500 ETF", "ETF", 1.85m, 560000000000L, 560.20m, "SPY" },
                    { 252, "Invesco QQQ Trust", "ETF", 0.68m, 280000000000L, 480.50m, "QQQ" },
                    { 253, "Vanguard S&P 500 ETF", "ETF", 1.70m, 480000000000L, 515.30m, "VOO" },
                    { 254, "Vanguard Total Stock ETF", "ETF", 0.92m, 390000000000L, 272.80m, "VTI" },
                    { 255, "iShares Russell 2000 ETF", "ETF", 0.72m, 68000000000L, 218.40m, "IWM" },
                    { 256, "Schwab US Dividend Equity", "ETF", 0.75m, 58000000000L, 82.50m, "SCHD" },
                    { 257, "JPMorgan Equity Premium", "ETF", 0.38m, 34000000000L, 58.20m, "JEPI" },
                    { 258, "JPMorgan Nasdaq Equity", "ETF", 0.42m, 18000000000L, 54.10m, "JEPQ" },
                    { 259, "VanEck Semiconductor ETF", "ETF", 0.45m, 24000000000L, 245.80m, "SMH" },
                    { 260, "Energy Select Sector SPDR", "ETF", 0.82m, 38000000000L, 88.20m, "XLE" },
                    { 261, "Financial Select Sector SPDR", "ETF", 0.22m, 42000000000L, 44.50m, "XLF" },
                    { 262, "Technology Select Sector", "ETF", 0.48m, 72000000000L, 225.10m, "XLK" },
                    { 263, "Health Care Select SPDR", "ETF", 0.58m, 40000000000L, 148.90m, "XLV" },
                    { 264, "Consumer Discretionary SPDR", "ETF", 0.45m, 22000000000L, 185.30m, "XLY" },
                    { 265, "Consumer Staples SPDR", "ETF", 0.52m, 17000000000L, 78.40m, "XLP" },
                    { 266, "Industrial Select Sector", "ETF", 0.48m, 21000000000L, 128.50m, "XLI" },
                    { 267, "Utilities Select Sector", "ETF", 0.58m, 16000000000L, 72.10m, "XLU" },
                    { 268, "Materials Select Sector", "ETF", 0.42m, 6200000000L, 89.40m, "XLB" },
                    { 269, "Vanguard Real Estate ETF", "Real Estate", 0.82m, 33000000000L, 88.50m, "VNQ" },
                    { 270, "Prologis Inc", "Real Estate", 0.96m, 113000000000L, 122.40m, "PLD" },
                    { 271, "American Tower", "Real Estate", 1.62m, 105000000000L, 225.80m, "AMT" },
                    { 272, "Equinix Inc", "Real Estate", 4.26m, 84000000000L, 880.50m, "EQIX" },
                    { 273, "Realty Income", "Real Estate", 0.26m, 54000000000L, 62.40m, "O" },
                    { 274, "Welltower Inc", "Real Estate", 0.67m, 71000000000L, 118.20m, "WELL" },
                    { 275, "Simon Property Group", "Real Estate", 2.00m, 54000000000L, 165.40m, "SPG" },
                    { 276, "Public Storage", "Real Estate", 3.00m, 57000000000L, 325.10m, "PSA" },
                    { 277, "Digital Realty Trust", "Real Estate", 1.22m, 50000000000L, 158.90m, "DLR" },
                    { 278, "VICI Properties", "Real Estate", 0.41m, 34000000000L, 32.50m, "VICI" },
                    { 279, "CBRE Group", "Real Estate", 0.00m, 35000000000L, 115.20m, "CBRE" },
                    { 280, "Weyerhaeuser Co", "Real Estate", 0.20m, 23000000000L, 31.80m, "WY" },
                    { 281, "AvalonBay Communities", "Real Estate", 1.70m, 30000000000L, 215.40m, "AVB" },
                    { 282, "Equity Residential", "Real Estate", 0.67m, 27000000000L, 72.80m, "EQR" },
                    { 283, "SBA Communications", "Real Estate", 0.98m, 25000000000L, 235.10m, "SBAC" },
                    { 284, "Invitation Homes", "Real Estate", 0.28m, 21000000000L, 35.20m, "INVH" },
                    { 285, "Alexandria Real Estate", "Real Estate", 1.27m, 20000000000L, 122.50m, "ARE" },
                    { 286, "Mid-America Apartment", "Real Estate", 1.47m, 18000000000L, 158.40m, "MAA" },
                    { 287, "Essex Property Trust", "Real Estate", 2.45m, 19000000000L, 295.10m, "ESS" },
                    { 288, "UDR Inc", "Real Estate", 0.42m, 14000000000L, 44.20m, "UDR" },
                    { 289, "Host Hotels & Resorts", "Real Estate", 0.20m, 13000000000L, 18.50m, "HST" },
                    { 290, "Camden Property Trust", "Real Estate", 1.03m, 13000000000L, 120.80m, "CPT" },
                    { 291, "Kimco Realty", "Real Estate", 0.24m, 15000000000L, 22.40m, "KIM" },
                    { 292, "Boston Properties", "Real Estate", 0.98m, 12000000000L, 78.50m, "BXP" },
                    { 293, "Regency Centers", "Real Estate", 0.67m, 13000000000L, 71.20m, "REG" },
                    { 294, "Federal Realty Investment", "Real Estate", 1.09m, 9500000000L, 112.40m, "FRT" },
                    { 295, "NNN REIT Inc", "Real Estate", 0.58m, 8800000000L, 48.20m, "NNN" },
                    { 296, "Agree Realty", "Real Estate", 0.25m, 7500000000L, 74.50m, "ADC" },
                    { 297, "STAG Industrial", "Real Estate", 0.12m, 7100000000L, 38.90m, "STAG" },
                    { 298, "EPR Properties", "Real Estate", 0.28m, 3600000000L, 48.10m, "EPR" },
                    { 299, "Omega Healthcare Investors", "Real Estate", 0.67m, 9800000000L, 38.40m, "OHI" },
                    { 300, "Medical Properties Trust", "Real Estate", 0.15m, 3100000000L, 5.20m, "MPW" },
                    { 301, "Thermo Fisher Scientific", "Healthcare", 0.39m, 201000000000L, 525.30m, "TMO" },
                    { 302, "Danaher Corporation", "Healthcare", 0.27m, 178000000000L, 245.60m, "DHR" },
                    { 303, "Philip Morris International", "Consumer Goods", 1.35m, 184000000000L, 118.40m, "PM" },
                    { 304, "Intuit Inc", "Software", 0.00m, 175000000000L, 625.80m, "INTU" },
                    { 305, "Lowe's Companies", "Retail", 1.15m, 152000000000L, 265.40m, "LOW" },
                    { 306, "Target Corporation", "Retail", 1.12m, 68000000000L, 148.90m, "TGT" },
                    { 307, "Dell Technologies", "Hardware", 0.45m, 89000000000L, 128.50m, "DELL" },
                    { 308, "HP Inc", "Hardware", 0.29m, 31000000000L, 32.60m, "HPQ" },
                    { 309, "Seagate Technology", "Hardware", 0.72m, 21000000000L, 98.40m, "STX" },
                    { 310, "Western Digital", "Hardware", 0.00m, 22000000000L, 68.20m, "WDC" },
                    { 311, "NXP Semiconductors", "Semiconductors", 1.01m, 62000000000L, 245.80m, "NXPI" },
                    { 312, "Microchip Technology", "Semiconductors", 0.45m, 44000000000L, 82.50m, "MCHP" },
                    { 313, "ON Semiconductor", "Semiconductors", 0.00m, 29000000000L, 68.40m, "ON" },
                    { 314, "Skyworks Solutions", "Semiconductors", 0.70m, 15000000000L, 92.60m, "SWKS" },
                    { 315, "Monolithic Power Systems", "Semiconductors", 0.50m, 30000000000L, 620.40m, "MPWR" },
                    { 316, "Tractor Supply Company", "Retail", 0.22m, 28000000000L, 52.80m, "TSCO" },
                    { 317, "Ross Stores", "Retail", 0.37m, 50000000000L, 148.50m, "ROST" },
                    { 318, "Dollar General", "Retail", 0.59m, 18000000000L, 82.40m, "DG" },
                    { 319, "Dollar Tree", "Retail", 0.00m, 15000000000L, 68.50m, "DLTR" },
                    { 320, "Kroger Co", "Retail", 0.32m, 42000000000L, 58.20m, "KR" },
                    { 321, "Sysco Corporation", "Consumer Goods", 0.51m, 36000000000L, 72.40m, "SYY" },
                    { 322, "General Mills", "Consumer Goods", 0.60m, 35000000000L, 62.80m, "GIS" },
                    { 323, "Kellanova", "Consumer Goods", 0.57m, 28000000000L, 82.10m, "K" },
                    { 324, "Hershey Company", "Consumer Goods", 1.37m, 34000000000L, 168.20m, "HSY" },
                    { 325, "Kraft Heinz", "Consumer Goods", 0.40m, 37000000000L, 30.40m, "KHC" },
                    { 326, "Constellation Brands", "Beverages", 1.01m, 33000000000L, 182.50m, "STZ" },
                    { 327, "Molson Coors", "Beverages", 0.44m, 12000000000L, 58.40m, "TAP" },
                    { 328, "Brown-Forman", "Beverages", 0.23m, 16000000000L, 34.20m, "BF-B" },
                    { 329, "Monster Beverage", "Beverages", 0.00m, 54000000000L, 55.40m, "MNST" },
                    { 330, "Keurig Dr Pepper", "Beverages", 0.23m, 44000000000L, 32.80m, "KDP" },
                    { 331, "Colgate-Palmolive", "Consumer Goods", 0.50m, 76000000000L, 92.40m, "CL" },
                    { 332, "Kimberly-Clark", "Consumer Goods", 1.22m, 46000000000L, 138.20m, "KMB" },
                    { 333, "Estee Lauder", "Consumer Goods", 0.66m, 28000000000L, 78.60m, "EL" },
                    { 334, "Ulta Beauty", "Retail", 0.00m, 18000000000L, 385.40m, "ULTA" },
                    { 335, "Lululemon Athletica", "Apparel", 0.00m, 40000000000L, 320.50m, "LULU" },
                    { 336, "Mohawk Industries", "Consumer Goods", 0.00m, 7500000000L, 118.40m, "MHK" },
                    { 337, "PulteGroup", "Homebuilders", 0.20m, 26000000000L, 128.50m, "PHM" },
                    { 338, "D.R. Horton", "Homebuilders", 0.30m, 48000000000L, 148.20m, "DHI" },
                    { 339, "Lennar Corporation", "Homebuilders", 0.50m, 35000000000L, 128.40m, "LEN" },
                    { 340, "NVR Inc", "Homebuilders", 0.00m, 24000000000L, 7800.00m, "NVR" },
                    { 341, "Masco Corporation", "Industrials", 0.29m, 15000000000L, 72.40m, "MAS" },
                    { 342, "Allegion plc", "Industrials", 0.48m, 11500000000L, 132.80m, "ALLE" },
                    { 343, "Cummins Inc", "Industrials", 1.68m, 47000000000L, 345.60m, "CMI" },
                    { 344, "Tesla Energy Holdings", "Energy", 0.00m, 42000000000L, 285.40m, "TSLA-E" },
                    { 345, "CoreWeave Inc", "Cloud Computing", 0.00m, 33000000000L, 68.40m, "CRWV" },
                    { 346, "Serve Robotics", "Robotics", 0.00m, 800000000L, 12.80m, "SERV" },
                    { 347, "Tempus AI Inc", "Healthcare AI", 0.00m, 10500000000L, 58.40m, "TEM" }
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
                name: "IX_Comments_StockId_CreatedOn",
                table: "Comments",
                columns: new[] { "StockId", "CreatedOn" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AppUserId",
                table: "RefreshTokens",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Symbol",
                table: "Stocks",
                column: "Symbol",
                unique: true);
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

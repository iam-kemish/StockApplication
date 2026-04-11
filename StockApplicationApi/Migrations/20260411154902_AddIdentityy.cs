using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Nobody is catching NVDA on hardware. Blackwell is already sold out for the next 4 quarters.", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GPU Lead is Insane" },
                    { 2, "RSI is screaming overbought. I'm waiting for a 5% pullback before adding more.", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Overbought?" },
                    { 3, "iPhone sales are flat, but the services revenue (App Store/iCloud) is where the real margin is.", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Services is the play" },
                    { 4, "The ecosystem lock-in is still the best in the world. Holding for the long term.", new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Walled Garden" },
                    { 5, "The new multimodal search is actually starting to steal market share back from the competitors.", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Gemini Integration" },
                    { 6, "Digital ad spend is recovering. GOOGL is the primary beneficiary here.", new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ad Spend" },
                    { 7, "Microsoft Cloud growth is decelerating slightly, but still dominant in enterprise.", new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Azure Cloud" },
                    { 8, "Reliable as always. Not a moonshot, but a bedrock for any portfolio.", new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Dividends" },
                    { 9, "Amazon's last-mile delivery costs are dropping. Expect a beat on earnings.", new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Logistics Cost" },
                    { 10, "AWS is basically a money printing machine at this point. Offsetting the retail losses.", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "AWS Margin" },
                    { 11, "TSMC is the best company in the world, but the China-Taiwan tension makes me nervous.", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Geopolitical Risk" },
                    { 12, "Reports show 3nm yields are better than expected. Huge for the next gen chips.", new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "3nm Yields" },
                    { 13, "Broadcom is the quiet winner of the AI race. Those custom ASICs are high margin.", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Networking Boom" },
                    { 14, "Meta's pivot back to its core ad business was the right move. Reels monetization is up.", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Ad Recovery" },
                    { 15, "Version 13 of FSD is actually usable. If they solve autonomy, the PE ratio makes sense.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "FSD Progress" },
                    { 16, "BYD and Xiaomi are eating Tesla's lunch in China. Scary trend.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Competition" },
                    { 17, "Zepbound demand is through the roof. LLY is now a biotech powerhouse.", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Weight Loss Drugs" },
                    { 18, "ASML literally has a monopoly on high-end lithography. You can't bet against them.", new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "EUV Dominance" },
                    { 19, "AMD is consistently taking server market share. EPYC chips are superior.", new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "AMD vs Intel" },
                    { 20, "Palantir's bootcamps are converting customers fast. The growth is finally here.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, "AIP Adoption" },
                    { 21, "If the economy slows down, everyone goes to Walmart. Safest stock right now.", new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Defensive Play" },
                    { 22, "Higher for longer means JPM keeps printing net interest income.", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Interest Rates" },
                    { 23, "Brent oil hitting $90 is great for Exxon's cash flow.", new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Oil Prices" },
                    { 24, "Costco just raised the membership fee and nobody left. That is brand power.", new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Membership Growth" },
                    { 25, "Doesn't matter if it's a recession or a boom, people drink Coke.", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Dividend King" },
                    { 26, "Nike is losing its edge to Hoka and On. Need more innovation in the lineup.", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Brand Fatigue" },
                    { 27, "Disney+ is finally profitable, but the parks are carrying the whole company.", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, "Streaming Losses" },
                    { 28, "MCD is the ultimate inflation hedge. People still need cheap calories.", new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "Global Scale" },
                    { 29, "Intel is a 5-year play. If they can build a foundry business, they win.", new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "Foundry Dreams" },
                    { 30, "Chevron's 4% yield is why I hold it. Solid management and buybacks.", new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, "Yield Play" },
                    { 31, "Buffett is sitting on a massive cash pile. Waiting for a crash to buy.", new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Cash Pile" },
                    { 32, "Visa is benefiting from the huge spike in international travel spending.", new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Travel Rebound" },
                    { 33, "Mastercard isn't scared of crypto. They are integrating it. Smart.", new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Fintech Fear" },
                    { 34, "Netflix password sharing ban worked. Subscribers are way up.", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Password Crackdown" },
                    { 35, "Oracle is no longer a legacy company. Their OCI is actually good.", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Cloud Pivot" },
                    { 36, "High interest rates are hurting Home Depot. People aren't remodeling.", new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Housing Market" },
                    { 37, "Salesforce is struggling to find new growth. The AI pivot needs to work.", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "SaaS Saturation" },
                    { 38, "Investment banking is waking up. Good news for Goldman.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, "M&A Activity" },
                    { 39, "Starbucks is getting crushed by local competition in China. Concern.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, "China Headwinds" },
                    { 40, "Caterpillar is the main play for the US infrastructure rebuild.", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, "Infrastructure Bill" },
                    { 41, "Compute is the new oil, and Nvidia owns the wells.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The New Gold" },
                    { 42, "If Eli Lilly can fix the Zepbound supply, this hits $1000 easily.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Supply Chain" },
                    { 43, "Adobe's AI tools are preventing users from switching to Canva.", new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, "Firefly AI" },
                    { 44, "Toyota was right about hybrids. Everyone is dumping pure EVs for them.", new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "Hybrid Strategy" },
                    { 45, "BABA is trading at a ridiculous multiple. Too cheap to ignore.", new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, "Deep Value" },
                    { 46, "Pfizer needs a new blockbuster drug. COVID revenue is long gone.", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, "Pipeline Woes" },
                    { 47, "Cisco's acquisition of Splunk is a game changer for their security stack.", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, "Security Growth" },
                    { 48, "UPS is aggressively automating hubs to lower union labor costs.", new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, "Automation" },
                    { 49, "Blackstone is dominating the private credit market. High yields.", new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, "Private Credit" },
                    { 50, "Premium smartphone market is rebounding, helping Qualcomm's bottom line.", new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, "Handset Recovery" },
                    { 51, "Vision Pro is a tech marvel, but who is actually buying it for $3500?", new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "VR/AR Doubt" },
                    { 52, "Once a company uses Teams and Excel, they never leave. Wide moat.", new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Enterprise Stickiness" },
                    { 53, "Amazon's ad business is growing faster than Google's. High margin.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Advertising Growth" },
                    { 54, "J&J still has the talc powder lawsuits hanging over them. Risky.", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Litigation Risks" },
                    { 55, "Pepsi is more of a snack company than a soda company now. I love it.", new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Snack Power" },
                    { 56, "P&G has 60 years of dividend increases. Hard to beat that record.", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, "Consumer Staple" },
                    { 57, "AstraZeneca is the leader in targeted cancer treatments. Huge moat.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, "Oncology Lead" },
                    { 58, "IBM is boring, but it pays a great dividend and the cloud is stable.", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, "Hybrid Cloud" },
                    { 59, "Abbott's Freestyle Libre is the gold standard for glucose monitoring.", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "MedTech Play" },
                    { 60, "Gross margins at 75% for a hardware company? Simply unheard of.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Margin Expansion" },
                    { 61, "Tencent is finally seeing the regulatory environment ease in China.", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Gaming Regulation" },
                    { 62, "BAC is the most rate-sensitive big bank. If rates drop, they suffer.", new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, "Net Interest Margin" },
                    { 63, "AbbVie is handling the loss of patent protection better than expected.", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, "Humira Cliff" },
                    { 64, "Dimon is the best CEO in banking. Period.", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Fortress Balance Sheet" },
                    { 65, "The VMware integration into Broadcom is finally yielding efficiency.", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "VMware Synergy" },
                    { 66, "Shorts is finally monetizing well enough to compete with TikTok.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "YouTube Shorts" },
                    { 67, "AMD's MI300X is the only real alternative to H100s right now.", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Data Center AI" },
                    { 68, "PLTR isn't just for the government anymore. Commercial is exploding.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, "Commercial Growth" },
                    { 69, "Everything depends on the August reveal. Pure speculation till then.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Robotaxi Event" },
                    { 70, "Another $100B in buybacks. Apple is a financial engineering masterpiece.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Buyback Machine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}

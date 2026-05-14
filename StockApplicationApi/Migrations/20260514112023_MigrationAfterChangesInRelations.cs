using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAfterChangesInRelations : Migration
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
                    StockId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

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

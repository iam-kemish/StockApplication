using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class CommentSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "Apple Inc", "Technology", 0.24m, 2800000000000L, 175.50m, "AAPL" },
                    { 2, "Microsoft", "Technology", 0.68m, 3000000000000L, 320.10m, "MSFT" },
                    { 3, "Alphabet", "Technology", 0.00m, 1800000000000L, 140.25m, "GOOGL" },
                    { 4, "Amazon", "E-Commerce", 0.00m, 1600000000000L, 155.80m, "AMZN" },
                    { 5, "Tesla", "Automotive", 0.00m, 700000000000L, 210.40m, "TSLA" },
                    { 6, "Nvidia", "Semiconductors", 0.16m, 2200000000000L, 600.75m, "NVDA" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Apple has one of the strongest ecosystems with loyal customers.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Strong Ecosystem" },
                    { 2, "Consistent performance and reliable dividends.", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Stable Growth" },
                    { 3, "Azure is driving massive growth for Microsoft.", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cloud Dominance" },
                    { 4, "Microsoft is leading in AI with OpenAI partnerships.", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "AI Leader" },
                    { 5, "Google still dominates digital advertising.", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ad Revenue Giant" },
                    { 6, "Search engine monopoly keeps revenue stable.", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Search King" },
                    { 7, "Amazon dominates global online retail.", new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "E-commerce Leader" },
                    { 8, "AWS contributes a huge portion of profits.", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "AWS Power" },
                    { 9, "Tesla is leading the electric vehicle revolution.", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "EV Pioneer" },
                    { 10, "Stock is highly volatile but has big growth potential.", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "High Volatility" },
                    { 11, "Nvidia is benefiting massively from AI demand.", new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "AI Boom" },
                    { 12, "Top player in GPUs for gaming and data centers.", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "GPU Leader" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}

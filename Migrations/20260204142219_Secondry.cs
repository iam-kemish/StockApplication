using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplication.Migrations
{
    /// <inheritdoc />
    public partial class Secondry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastDiv",
                table: "Stocks",
                newName: "LastDiv");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "LastDiv",
                table: "Stocks",
                newName: "lastDiv");
        }
    }
}

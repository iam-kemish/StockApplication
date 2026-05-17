using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRefreshTokenfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revoked",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);
        }
    }
}

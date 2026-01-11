using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Point72Library.Migrations
{
    /// <inheritdoc />
    public partial class AddLibrarianFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowedAt",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ReturnedAt",
                table: "Loans");

            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "Loans",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLibrarian",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Returned",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsLibrarian",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowedAt",
                table: "Loans",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedAt",
                table: "Loans",
                type: "TEXT",
                nullable: true);
        }
    }
}

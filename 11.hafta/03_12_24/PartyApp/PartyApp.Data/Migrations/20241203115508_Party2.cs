using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Party2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "EventDate", "EventName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noel Partisi" },
                    { 2, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doğum Günü Partisi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

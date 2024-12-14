using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    NumberOfPeople = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitationParticipants",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationParticipants", x => new { x.InvitationId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "EventDate", "EventName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noel Partisi" },
                    { 2, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doğum Günü Partisi" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Age", "Email", "FullName", "NumberOfPeople", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, (byte)42, "q7@gmail.com", "Ricardo Quaresma", (byte)1, "" },
                    { 2, (byte)38, "cr7@gmail.com", "Cristiano Ronaldo", (byte)3, "1234567890" },
                    { 3, (byte)36, "lm10@gmail.com", "Lionel Messi", (byte)4, "0987654321" },
                    { 4, (byte)32, "njr10@gmail.com", "Neymar Jr.", (byte)2, "1122334455" },
                    { 5, (byte)25, "km7@gmail.com", "Kylian Mbappe", (byte)1, "6677889900" },
                    { 6, (byte)42, "zi9@gmail.com", "Zlatan Ibrahimovic", (byte)5, "5566778899" },
                    { 7, (byte)38, "sr4@gmail.com", "Sergio Ramos", (byte)3, "4455667788" },
                    { 8, (byte)38, "lm10@gmail.com", "Luka Modric", (byte)2, "2233445566" },
                    { 9, (byte)32, "kdb17@gmail.com", "Kevin De Bruyne", (byte)4, "3344556677" },
                    { 10, (byte)36, "rl9@gmail.com", "Robert Lewandowski", (byte)3, "7788990011" },
                    { 11, (byte)32, "ms11@gmail.com", "Mohamed Salah", (byte)2, "9988776655" }
                });

            migrationBuilder.InsertData(
                table: "InvitationParticipants",
                columns: new[] { "InvitationId", "ParticipantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 9 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 10 },
                    { 2, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitationParticipants_ParticipantId",
                table: "InvitationParticipants",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitationParticipants");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}

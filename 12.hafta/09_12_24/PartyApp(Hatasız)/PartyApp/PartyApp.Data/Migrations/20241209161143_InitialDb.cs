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
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
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
                    { 1, (byte)48, "didierdrogba@gmail.com", "Didier Drogba", (byte)1, "" },
                    { 2, (byte)37, "lionelmessi@gmail.com", "Lionel Messi", (byte)3, "123-456-7890" },
                    { 3, (byte)39, "cristianoronaldo@gmail.com", "Cristiano Ronaldo", (byte)5, "234-567-8901" },
                    { 4, (byte)32, "neymar@gmail.com", "Neymar Jr.", (byte)2, "345-678-9012" },
                    { 5, (byte)25, "kylianmbappe@gmail.com", "Kylian Mbappé", (byte)4, "456-789-0123" },
                    { 6, (byte)31, "mohamedsalah@gmail.com", "Mohamed Salah", (byte)4, "567-890-1234" },
                    { 7, (byte)33, "kevindebruyne@gmail.com", "Kevin De Bruyne", (byte)2, "678-901-2345" },
                    { 8, (byte)30, "harrykane@gmail.com", "Harry Kane", (byte)3, "789-012-3456" },
                    { 9, (byte)38, "sergioramos@gmail.com", "Sergio Ramos", (byte)2, "890-123-4567" },
                    { 10, (byte)35, "robertlewandowski@gmail.com", "Robert Lewandowski", (byte)4, "901-234-5678" }
                });

            migrationBuilder.InsertData(
                table: "InvitationParticipants",
                columns: new[] { "InvitationId", "ParticipantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 10 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
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

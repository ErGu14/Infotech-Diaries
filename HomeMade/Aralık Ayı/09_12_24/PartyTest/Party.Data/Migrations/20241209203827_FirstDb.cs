using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Party.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Davetliler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(name: "Ad-Soyad", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    EPosta = table.Column<string>(name: "E-Posta", type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TelefonNumarası = table.Column<string>(name: "Telefon-Numarası", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EkstraKatılım = table.Column<byte>(name: "Ekstra-Katılım", type: "tinyint", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Davetliler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdı = table.Column<string>(name: "Etkinlik-Adı", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EtkinlikTarihi = table.Column<DateTime>(name: "Etkinlik-Tarihi", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
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
                    table.PrimaryKey("PK_InvitationParticipants", x => new { x.ParticipantId, x.InvitationId });
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Davetliler_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Davetliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Etkinlikler_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Etkinlikler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Davetliler",
                columns: new[] { "Id", "Age", "E-Posta", "Ad-Soyad", "Ekstra-Katılım", "Telefon-Numarası" },
                values: new object[,]
                {
                    { 1, (byte)48, "didierdrogba@gmail.com", "Didier Drogba", (byte)1, "555-0001" },
                    { 2, (byte)36, "lionelmessi@gmail.com", "Lionel Messi", (byte)2, "555-0002" },
                    { 3, (byte)39, "cristianoronaldo@gmail.com", "Cristiano Ronaldo", (byte)3, "555-0003" },
                    { 4, (byte)25, "kylianmbappe@gmail.com", "Kylian Mbappe", (byte)1, "555-0004" },
                    { 5, (byte)32, "neymarjr@gmail.com", "Neymar Jr", (byte)2, "555-0005" },
                    { 6, (byte)33, "kevindebruyne@gmail.com", "Kevin De Bruyne", (byte)1, "555-0006" },
                    { 7, (byte)35, "robertlewandowski@gmail.com", "Robert Lewandowski", (byte)4, "555-0007" },
                    { 8, (byte)38, "sergioramos@gmail.com", "Sergio Ramos", (byte)2, "555-0008" },
                    { 9, (byte)38, "lukamodric@gmail.com", "Luka Modric", (byte)1, "555-0009" },
                    { 10, (byte)32, "virgilvandijk@gmail.com", "Virgil van Dijk", (byte)1, "555-0010" },
                    { 11, (byte)31, "mohamedsalah@gmail.com", "Mohamed Salah", (byte)3, "555-0011" },
                    { 12, (byte)32, "sadiomane@gmail.com", "Sadio Mane", (byte)2, "555-0012" },
                    { 13, (byte)31, "harrykane@gmail.com", "Harry Kane", (byte)2, "555-0013" },
                    { 14, (byte)30, "raheemsterling@gmail.com", "Raheem Sterling", (byte)1, "555-0014" },
                    { 15, (byte)31, "paulpogba@gmail.com", "Paul Pogba", (byte)1, "555-0015" },
                    { 16, (byte)33, "antoinegriezmann@gmail.com", "Antoine Griezmann", (byte)2, "555-0016" }
                });

            migrationBuilder.InsertData(
                table: "Etkinlikler",
                columns: new[] { "Id", "Etkinlik-Tarihi", "Etkinlik-Adı" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beşiktaş Fenerbahçe Maçı" },
                    { 2, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Düğün Organizasyonu" },
                    { 3, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyun Turnuvası" }
                });

            migrationBuilder.InsertData(
                table: "InvitationParticipants",
                columns: new[] { "InvitationId", "ParticipantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 1, 7 },
                    { 3, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 2, 15 },
                    { 2, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitationParticipants_InvitationId",
                table: "InvitationParticipants",
                column: "InvitationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitationParticipants");

            migrationBuilder.DropTable(
                name: "Davetliler");

            migrationBuilder.DropTable(
                name: "Etkinlikler");
        }
    }
}

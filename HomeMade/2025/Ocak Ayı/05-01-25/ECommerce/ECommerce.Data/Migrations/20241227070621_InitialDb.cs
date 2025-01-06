using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115c7796-cfac-44de-91b5-916eaae125b5", null, "Administrator role", "Admin", "ADMIN" },
                    { "811f466c-9d06-43f8-a054-24aedbb4161b", null, "Regular user role", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14a0183f-1e96-4930-a83d-6ef5f22d8c09", 0, "", "", "846ae808-fbea-4f84-8349-a0d3f3b39b25", new DateTime(2024, 12, 27, 10, 6, 20, 426, DateTimeKind.Local).AddTicks(5816), "suser@gmail.com", true, "Sample", 1, "User", false, null, "SUSER@GMAIL.COM", "SUSER@GMAIL.COM", "AQAAAAIAAYagAAAAEMVvrXDi6Qtc981/vFEfHWuQA3YxJT800gSD1mkjIRJ9J4djVRi/h/rNK7W3OvF35A==", "", false, "530688c2-f495-4a7d-bf36-6a02e8135955", false, "suser@gmail.com" },
                    { "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", 0, "", "", "7978cdd3-fba6-4eb6-a9d5-b3916de0cb72", new DateTime(2024, 12, 27, 10, 6, 20, 367, DateTimeKind.Local).AddTicks(5928), "sadmin@gmail.com", true, "Sample", 1, "Admin", false, null, "SADMIN@GMAIL.COM", "SADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEI5pBr2eIQf2zK1yJDRL0ZyT1J9Gw72DmE6t2eKKClBhmILfiRv1vZvcp0JbLTle7g==", "", false, "63785466-cbcb-4e7b-959e-de87165c4fb7", false, "sadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5007), "Elektronik ürünler", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronik" },
                    { 2, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5011), "Giyim ürünleri", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giyim" },
                    { 3, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5014), "Kozmetik ürünler", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozmetik" },
                    { 4, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5015), "Kitaplar", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kitap" },
                    { 5, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5016), "Hediyelik eşyalar", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hediyelik Eşya" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "ModifiedDate", "Name", "Price", "Properties" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5170), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akıllı Telefon", 2999.99m, "Son model akıllı telefon" },
                    { 2, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5178), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 4999.99m, "Yüksek performanslı laptop" },
                    { 3, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5179), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamera", 1999.99m, "Yüksek çözünürlüklü kamera" },
                    { 4, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5181), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tablet", 1999.99m, "Taşınabilir tablet" },
                    { 5, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5182), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluetooth Hoparlör", 399.99m, "Kablosuz hoparlör" },
                    { 6, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5185), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akıllı Saat", 799.99m, "Akıllı saat" },
                    { 7, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5186), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kulaklık", 299.99m, "Kablosuz kulaklık" },
                    { 8, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5187), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dizüstü Bilgisayar", 3499.99m, "Hafif dizüstü bilgisayar" },
                    { 9, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5189), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyun Konsolu", 2499.99m, "Yeni nesil oyun konsolu" },
                    { 10, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5191), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaüstü Bilgisayar", 3999.99m, "Güçlü masaüstü bilgisayar" },
                    { 11, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5192), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazıcı", 499.99m, "Renkli yazıcı" },
                    { 12, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5194), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarayıcı", 299.99m, "Doküman tarayıcı" },
                    { 13, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5195), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Projeor", 1999.99m, "Ev sinema sistemi için projektör" },
                    { 14, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5196), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamera Lens", 799.99m, "Yüksek kaliteli lens" },
                    { 15, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5198), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksiyon Kamerası", 1499.99m, "Aksiyon çekimleri için kamera" },
                    { 16, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5200), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Küçük Ev Aletleri", 299.99m, "Küçük ev aletleri" },
                    { 17, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5201), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mutfak Robotu", 899.99m, "Mutfak robotu" },
                    { 18, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5203), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blender", 199.99m, "Blender" },
                    { 19, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5204), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikser", 149.99m, "Mikser" },
                    { 20, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5207), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fırın", 1999.99m, "Dijital fırın" },
                    { 21, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5208), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruj", 49.99m, "Kırmızı ruj" },
                    { 22, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5210), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parfüm", 199.99m, "Kadın parfümü" },
                    { 23, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5214), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krem", 79.99m, "Nemlendirici krem" },
                    { 24, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5216), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şampuan", 39.99m, "Saç şampuanı" },
                    { 25, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5217), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dudak Balmı", 19.99m, "Nemlendirici dudak balmı" },
                    { 26, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5218), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makyaj Seti", 299.99m, "Makyaj seti" },
                    { 27, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5219), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Göz Farı", 59.99m, "Göz farı" },
                    { 28, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5221), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oje", 29.99m, "Renkli oje" },
                    { 29, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5222), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cilt Bakım Seti", 199.99m, "Cilt bakım seti" },
                    { 30, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5223), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vücut Losyonu", 89.99m, "Vücut losyonu" },
                    { 31, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5224), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saç Spreyi", 39.99m, "Saç spreyi" },
                    { 32, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5225), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makyaj Ayna", 49.99m, "Makyaj aynası" },
                    { 33, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5228), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tırnak Bakım Seti", 29.99m, "Tırnak bakım seti" },
                    { 34, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5274), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüz Maskesi", 19.99m, "Yüz maskesi" },
                    { 35, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5275), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Göz Kremi", 59.99m, "Göz kremi" },
                    { 36, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5277), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dudak Peelingi", 29.99m, "Dudak peelingi" },
                    { 37, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5278), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cilt Temizleme Jeli", 39.99m, "Cilt temizleme jeli" },
                    { 38, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5279), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vücut Scrub'ı", 49.99m, "Vücut scrub'ı" },
                    { 39, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5280), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saç Maskesi", 59.99m, "Saç maskesi" },
                    { 40, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5282), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makyaj Fırçası", 19.99m, "Makyaj fırçası" },
                    { 41, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5284), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tişört", 99.99m, "Pamuklu tişört" },
                    { 42, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5285), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pantolon", 149.99m, "Şık pantolon" },
                    { 43, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5287), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elbise", 199.99m, "Şık elbise" },
                    { 44, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5288), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceket", 299.99m, "Şık ceket" },
                    { 45, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5289), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaban", 399.99m, "Kış kabanı" },
                    { 46, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5290), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roman", 39.99m, "Roman" },
                    { 47, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5292), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilim Kurgu", 29.99m, "Bilim kurgu kitabı" },
                    { 48, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5293), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarih Kitabı", 34.99m, "Tarih kitabı" },
                    { 49, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5294), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çocuk Kitabı", 19.99m, "Çocuklar için kitap" },
                    { 50, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5295), "image1.png", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemek Kitabı", 49.99m, "Yemek tarifleri kitabı" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "811f466c-9d06-43f8-a054-24aedbb4161b", "14a0183f-1e96-4930-a83d-6ef5f22d8c09" },
                    { "115c7796-cfac-44de-91b5-916eaae125b5", "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "CreatedDate", "IsActive", "ModifiedDate", "OrderStatus" },
                values: new object[,]
                {
                    { 101, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 102, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 103, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 104, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 105, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 106, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 107, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 108, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 109, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 110, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 111, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 112, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 113, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 114, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 115, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 116, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 117, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 118, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 119, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 120, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 121, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 122, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 123, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 124, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 125, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 126, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 127, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 128, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 129, "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 130, "14a0183f-1e96-4930-a83d-6ef5f22d8c09", new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 5, 5 },
                    { 1, 6 },
                    { 5, 6 },
                    { 1, 7 },
                    { 5, 7 },
                    { 1, 8 },
                    { 5, 8 },
                    { 1, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 5, 10 },
                    { 1, 11 },
                    { 5, 11 },
                    { 1, 12 },
                    { 5, 12 },
                    { 1, 13 },
                    { 5, 13 },
                    { 1, 14 },
                    { 5, 14 },
                    { 1, 15 },
                    { 5, 15 },
                    { 3, 21 },
                    { 5, 21 },
                    { 3, 22 },
                    { 5, 22 },
                    { 3, 23 },
                    { 5, 23 },
                    { 3, 24 },
                    { 5, 24 },
                    { 3, 25 },
                    { 5, 25 },
                    { 3, 26 },
                    { 5, 26 },
                    { 3, 27 },
                    { 5, 27 },
                    { 3, 28 },
                    { 5, 28 },
                    { 3, 29 },
                    { 5, 29 },
                    { 3, 30 },
                    { 5, 30 },
                    { 3, 31 },
                    { 5, 31 },
                    { 3, 32 },
                    { 5, 32 },
                    { 3, 33 },
                    { 5, 33 },
                    { 3, 34 },
                    { 5, 34 },
                    { 3, 35 },
                    { 5, 35 },
                    { 3, 36 },
                    { 5, 36 },
                    { 3, 37 },
                    { 5, 37 },
                    { 3, 38 },
                    { 5, 38 },
                    { 3, 39 },
                    { 5, 39 },
                    { 3, 40 },
                    { 5, 40 },
                    { 2, 41 },
                    { 5, 41 },
                    { 2, 42 },
                    { 5, 42 },
                    { 2, 43 },
                    { 5, 43 },
                    { 2, 44 },
                    { 5, 44 },
                    { 2, 45 },
                    { 5, 45 },
                    { 4, 46 },
                    { 5, 46 },
                    { 4, 47 },
                    { 5, 47 },
                    { 4, 48 },
                    { 5, 48 },
                    { 4, 49 },
                    { 5, 49 },
                    { 4, 50 },
                    { 5, 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedDate", "IsActive", "ModifiedDate", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 201, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5696), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 1, 1, 2999.99m },
                    { 202, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5698), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 2, 1, 4999.99m },
                    { 203, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5700), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 3, 1, 1999.99m },
                    { 204, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5701), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 4, 1, 1999.99m },
                    { 205, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5702), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 5, 1, 399.99m },
                    { 206, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5703), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 6, 1, 799.99m },
                    { 207, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5703), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 7, 1, 299.99m },
                    { 208, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5704), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 8, 1, 3499.99m },
                    { 209, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5705), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 9, 1, 2499.99m },
                    { 210, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5706), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 10, 1, 3999.99m },
                    { 211, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5707), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 11, 1, 499.99m },
                    { 212, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5708), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 12, 1, 299.99m },
                    { 213, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5709), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 13, 1, 1999.99m },
                    { 214, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5711), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 14, 1, 799.99m },
                    { 215, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5712), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 15, 1, 1499.99m },
                    { 216, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5713), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 16, 1, 299.99m },
                    { 217, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5714), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 17, 1, 899.99m },
                    { 218, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5715), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 118, 18, 1, 199.99m },
                    { 219, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5716), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 19, 1, 149.99m },
                    { 220, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5717), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 20, 1, 1999.99m },
                    { 221, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5718), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 21, 1, 49.99m },
                    { 222, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5719), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 22, 1, 199.99m },
                    { 223, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5720), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 23, 1, 79.99m },
                    { 224, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5753), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 24, 1, 39.99m },
                    { 225, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5755), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 25, 1, 19.99m },
                    { 226, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5756), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 26, 1, 299.99m },
                    { 227, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5757), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 27, 1, 59.99m },
                    { 228, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5758), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 28, 1, 29.99m },
                    { 229, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5759), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 29, 1, 199.99m },
                    { 230, new DateTime(2024, 12, 27, 7, 6, 20, 367, DateTimeKind.Utc).AddTicks(5760), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 30, 1, 89.99m }
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
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ApplicationUserId",
                table: "Baskets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
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
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

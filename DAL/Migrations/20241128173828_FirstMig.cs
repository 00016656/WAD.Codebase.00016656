using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    SquareFeet = table.Column<double>(type: "float", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "anvar@example.com", "Aliyev Anvar", "hashed_password_1", "+998901234567", "Agent" },
                    { 2, "gulnara@example.com", "Bekova Gulnara", "hashed_password_2", "+998903456789", "Seller" },
                    { 3, "jamshid@example.com", "Karimov Jamshid", "hashed_password_3", "+998902345678", "Buyer" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "Description", "ListedDate", "Price", "PropertyType", "SquareFeet", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Amir Temur Avenue, Tashkent", 2, 3, "A modern 3-bedroom apartment located in Tashkent City.", new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6123), 150000m, "Apartment", 1200.0, "Luxury Apartment in Tashkent City", 1 },
                    { 2, "Bukhara Street, Samarkand", 3, 4, "A spacious family house with a garden in Samarkand.", new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6137), 100000m, "House", 2000.0, "Cozy House in Samarkand", 2 },
                    { 3, "Navoi Avenue, Andijan", 2, 0, "Prime location for a business in Andijan.", new DateTime(2024, 11, 28, 22, 38, 27, 817, DateTimeKind.Local).AddTicks(6139), 250000m, "Commercial", 3000.0, "Commercial Space in Andijan", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

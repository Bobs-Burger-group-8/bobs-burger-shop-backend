using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bobs_burger_api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "ingredients", "name", "price" },
                values: new object[,]
                {
                    { 1, "ingredient", "Deliciously melted cheese", new List<int>(), "cheese", 1.0 },
                    { 2, "ingredient", "No better buns exist", new List<int>(), "bun", 1.0 },
                    { 3, "ingredient", "Very green", new List<int>(), "lettuce", 1.0 },
                    { 4, "ingredient", "Bobs super special, super secret burger sauce", new List<int>(), "bobs-secret-sauce", 2.0 },
                    { 5, "ingredient", "100% juicy meat", new List<int>(), "beef-patty", 1.0 },
                    { 6, "ingredient", "Fermented for days", new List<int>(), "pickle", 1.0 },
                    { 7, "ingredient", "Could make you cry", new List<int>(), "onion", 1.0 },
                    { 8, "ingredient", "Very red", new List<int>(), "ketchup", 1.0 },
                    { 9, "ingredient", "Very yellow", new List<int>(), "mustard", 1.0 },
                    { 10, "burger", "Biggest bob there is", new List<int> { 1, 2, 3, 4, 5, 6, 7 }, "Big Bob", 9.9900000000000002 },
                    { 11, "burger", "Biggest bob there is", new List<int> { 1, 2, 4, 6, 7, 8, 9 }, "Quarter Bob", 9.9900000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 11);
        }
    }
}

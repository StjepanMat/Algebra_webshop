using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderModelChangeAndNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "Description", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 50, true, "Description", 10.99m, 10m, "Rambo" },
                    { 51, true, "Description 2", 13.99m, 8m, "Rambo 2" },
                    { 52, true, "Description 3", 15.99m, 12m, "Rambo 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 52);
        }
    }
}

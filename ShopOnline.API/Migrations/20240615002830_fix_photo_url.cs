using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.API.Migrations
{
    /// <inheritdoc />
    public partial class fix_photo_url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "/Images/Beauty/Beauty1.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "https://rb.gy/ctcygu");
        }
    }
}

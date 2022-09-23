using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABISoft.WebAPI1.Migrations
{
    public partial class SeedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2022, 7, 25, 8, 31, 47, 733, DateTimeKind.Local).AddTicks(1099), null, "Bilgisayar", 15000m, 300 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2022, 6, 28, 8, 31, 47, 736, DateTimeKind.Local).AddTicks(5584), null, "Telefon", 10000m, 500 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2022, 5, 29, 8, 31, 47, 736, DateTimeKind.Local).AddTicks(5637), null, "Klavye", 100m, 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

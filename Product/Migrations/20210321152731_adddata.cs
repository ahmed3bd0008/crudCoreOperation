using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PhotoPath", "ProductDataTime", "ProductName" },
                values: new object[] { 1, "1", new DateTime(2021, 3, 21, 17, 27, 30, 275, DateTimeKind.Local).AddTicks(178), "product1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

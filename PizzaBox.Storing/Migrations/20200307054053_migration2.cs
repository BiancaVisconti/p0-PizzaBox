using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[] { 4L, new DateTime(2020, 3, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[] { 5L, new DateTime(2020, 3, 6, 10, 9, 0, 0, DateTimeKind.Unspecified), 2L, 2L });

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 3L,
                column: "Name",
                value: "MiPizza");

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "Amount", "OrderId", "PizzaId" },
                values: new object[] { 5L, 2, 4L, 6L });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "Amount", "OrderId", "PizzaId" },
                values: new object[] { 6L, 1, 5L, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5L);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 3L,
                column: "Name",
                value: "MyPizza");
        }
    }
}

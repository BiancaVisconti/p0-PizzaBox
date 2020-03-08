using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2019, 11, 1, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2019, 11, 17, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2019, 12, 5, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2019, 12, 6, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5L,
                column: "Date",
                value: new DateTime(2019, 12, 31, 15, 9, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6L,
                column: "Date",
                value: new DateTime(2020, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7L,
                column: "Date",
                value: new DateTime(2020, 2, 24, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 8L,
                column: "Date",
                value: new DateTime(2020, 3, 4, 14, 25, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 8, 21, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Name", "NumMenu", "Price" },
                values: new object[] { 10L, "thick crust, tomato sauce, tomate, pineapple, avocado", "GIANT SUPER PIZZA", 10, 59.90m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2020, 3, 1, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2020, 2, 17, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2020, 3, 5, 7, 9, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2020, 3, 6, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5L,
                column: "Date",
                value: new DateTime(2020, 3, 6, 15, 9, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6L,
                column: "Date",
                value: new DateTime(2020, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7L,
                column: "Date",
                value: new DateTime(2020, 1, 6, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 8L,
                column: "Date",
                value: new DateTime(2019, 11, 12, 14, 25, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2019, 12, 31, 20, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

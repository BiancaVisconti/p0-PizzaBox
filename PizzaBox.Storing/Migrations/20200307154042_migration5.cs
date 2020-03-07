using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5L,
                column: "Date",
                value: new DateTime(2020, 3, 6, 15, 9, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 4L,
                column: "PizzaId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 1L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 2L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 3L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 4L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 5L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 6L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions");

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Name", "NumMenu", "Price" },
                values: new object[,]
                {
                    { 7L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "SMALL DELICIOUS PIZZA", 7, 5.50m },
                    { 9L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "LARGE DELICIOUS PIZZA", 9, 16.50m },
                    { 8L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "MEDIUM DELICIOUS PIZZA", 8, 10.50m }
                });

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 1L,
                column: "Name",
                value: "MammaMia");

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 6L, "Mesquite 87", "PizzaLover", 6, "pizza" },
                    { 5L, "Cooper 132", "Mangiata", 5, "comer" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "Password",
                value: "bianca");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Password",
                value: "silvana");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3L,
                columns: new[] { "Name", "Password" },
                values: new object[] { "MacarenaRodriguez", "maca" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4L,
                columns: new[] { "Address", "Name", "Password" },
                values: new object[] { "3 Poniente", "VictoriaTorres", "vicky" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5L,
                column: "Address",
                value: "Avenida Beio 15");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 10L, "Lomas de Montenar 1190", "Sofia", "sofia" },
                    { 8L, "Blanca Estela 76", "Fernanda", "ferna" },
                    { 7L, "Avenida Beio 15", "JennyLoe", "jenny" },
                    { 6L, "15 Norte", "NancyCastro", "nancy" },
                    { 9L, "Los Pellines 950", "Francisca", "fran" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 11, 12, 14, 25, 0, 0, DateTimeKind.Unspecified), 4L, 7L },
                    { 9L, new DateTime(2019, 12, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), 3L, 8L },
                    { 6L, new DateTime(2020, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, 9L },
                    { 7L, new DateTime(2020, 1, 6, 12, 30, 0, 0, DateTimeKind.Unspecified), 5L, 10L }
                });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "Amount", "OrderId", "PizzaId" },
                values: new object[,]
                {
                    { 11L, 3, 8L, 5L },
                    { 12L, 1, 8L, 1L },
                    { 13L, 2, 9L, 9L },
                    { 14L, 1, 9L, 7L },
                    { 7L, 3, 6L, 7L },
                    { 8L, 1, 6L, 8L },
                    { 9L, 7, 7L, 9L },
                    { 10L, 2, 7L, 6L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5L,
                column: "Date",
                value: new DateTime(2020, 3, 6, 10, 9, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderPizza",
                keyColumn: "OrderPizzaId",
                keyValue: 4L,
                column: "PizzaId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 1L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 2L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 3L,
                column: "Description",
                value: "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 4L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 5L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 6L,
                column: "Description",
                value: "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions");

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 1L,
                column: "Name",
                value: "MammaMía");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "Password",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Password",
                value: "67890");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3L,
                columns: new[] { "Name", "Password" },
                values: new object[] { "JuanitoPerez", "asasa" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4L,
                columns: new[] { "Address", "Name", "Password" },
                values: new object[] { "Avenida 89", "MariaSoto", "trebol" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5L,
                column: "Address",
                value: "Avenida beio 15");
        }
    }
}

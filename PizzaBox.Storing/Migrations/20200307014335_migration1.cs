using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    NumMenu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NumMenu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderPizzaId = table.Column<long>(nullable: false),
                    PizzaId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.OrderPizzaId);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Name", "NumMenu", "Price" },
                values: new object[,]
                {
                    { 1L, "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", "SMALL HAWAIIAN PIZZA", 1, 5.00m },
                    { 2L, "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", "MEDIUM HAWAIIAN PIZZA", 2, 9.50m },
                    { 3L, "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions", "LARGE HAWAIIAN PIZZA", 3, 13.90m },
                    { 4L, "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", "SMALL EXQUISITE PIZZA", 4, 6.00m },
                    { 5L, "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", "MEDIUM EXQUISITE PIZZA", 5, 11.00m },
                    { 6L, "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", "LARGE EXQUISITE PIZZA", 6, 15.50m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 1L, "Cooper 786", "MammaMía", 1, "13131" },
                    { 2L, "Mitchel 83", "DiegoPizza", 2, "58585" },
                    { 3L, "Mesquite 476", "MyPizza", 3, "lolol" },
                    { 4L, "Abram 34", "TuPizza", 4, "trole" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 1L, "Central 960", "BiancaVisconti", "12345" },
                    { 2L, "Street 4250", "SilvanaRoncagliolo", "67890" },
                    { 3L, "Calle 13", "JuanitoPerez", "asasa" },
                    { 4L, "Avenida 89", "MariaSoto", "trebol" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[] { 1L, new DateTime(2020, 3, 1, 7, 9, 14, 0, DateTimeKind.Unspecified), 1L, 1L });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[] { 2L, new DateTime(2020, 2, 17, 7, 9, 14, 0, DateTimeKind.Unspecified), 2L, 2L });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[] { 3L, new DateTime(2020, 3, 7, 7, 9, 14, 0, DateTimeKind.Unspecified), 1L, 2L });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "Amount", "OrderId", "PizzaId" },
                values: new object[,]
                {
                    { 1L, 2, 1L, 3L },
                    { 2L, 3, 1L, 5L },
                    { 3L, 1, 2L, 2L },
                    { 4L, 1, 3L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

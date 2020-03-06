using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    StoreId1 = table.Column<long>(nullable: true),
                    UserId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId1",
                        column: x => x.StoreId1,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Inventory = table.Column<int>(nullable: false),
                    NumMenu = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.OrderId, x.PizzaId });
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
                columns: new[] { "PizzaId", "Description", "Inventory", "Name", "NumMenu", "OrderId", "Price" },
                values: new object[,]
                {
                    { 637190792455674088L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 30, "SMALL HAWAIIAN PIZZA", 1, null, 5.00m },
                    { 637190792455675539L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 18, "MEDIUM HAWAIIAN PIZZA", 2, null, 9.50m },
                    { 637190792455675591L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 12, "LARGE HAWAIIAN PIZZA", 3, null, 13.90m },
                    { 637190792455675594L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 24, "SMALL EXQUISITE PIZZA", 4, null, 6.00m },
                    { 637190792455675595L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 30, "MEDIUM EXQUISITE PIZZA", 5, null, 11.00m },
                    { 637190792455675645L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 17, "LARGE EXQUISITE PIZZA", 6, null, 15.50m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 637190792455617291L, "Cooper 786", "MammaMía", 1, "13131" },
                    { 637190792455617811L, "Mitchel 83", "DiegoPizza", 2, "58585" },
                    { 637190792455617837L, "Mesquite 476", "MyPizza", 3, "lolol" },
                    { 637190792455617839L, "Abram 34", "TuPizza", 4, "trole" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 637190792455576470L, "Central 960", "BiancaVisconti", "12345" },
                    { 637190792455599298L, "Street 4250", "SilvanaRoncagliolo", "67890" },
                    { 637190792455599343L, "Calle 13", "JuanitoPerez", "asasa" },
                    { 637190792455599346L, "Avenida 89", "MariaSoto", "trebol" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId1",
                table: "Order",
                column: "StoreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId1",
                table: "Order",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizza",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

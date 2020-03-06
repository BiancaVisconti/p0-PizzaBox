using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_OrderPizza", x => new { x.PizzaId, x.OrderId });
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
                    { 637190406300436451L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 30, "small hawaiian pizza", 1, null, 5.00m },
                    { 637190406300437879L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 18, "medium hawaiian pizza", 2, null, 9.50m },
                    { 637190406300437926L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 12, "large hawaiian pizza", 3, null, 13.90m },
                    { 637190406300437929L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 24, "small exquisite pizza", 4, null, 6.00m },
                    { 637190406300437931L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 30, "medium exquisite pizza", 5, null, 11.00m },
                    { 637190406300437932L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 17, "large exquisite pizza", 6, null, 15.50m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 637190406300380263L, "Cooper 786", "Mamma Mía", 1, "13131" },
                    { 637190406300380768L, "Mitchel 83", "Diego Pizza", 2, "58585" },
                    { 637190406300380795L, "Mesquite 476", "My Pizza", 3, "lolol" },
                    { 637190406300380797L, "Abram 34", "Tu Pizza", 4, "trole" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 637190406300342160L, "Central 960", "BiancaVisconti", "12345" },
                    { 637190406300364055L, "Street 4250", "SilvanaRoncagliolo", "67890" },
                    { 637190406300364094L, "Calle 13", "JuanitoPerez", "asasa" },
                    { 637190406300364097L, "Avenida 89", "MariaSoto", "trebol" }
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
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

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

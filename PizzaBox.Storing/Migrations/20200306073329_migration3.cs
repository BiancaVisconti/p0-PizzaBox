using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903986496L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903988114L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903988171L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903988174L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903988176L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190509903988178L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190509903933334L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190509903933840L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190509903933865L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190509903933867L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190509903896366L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190509903917904L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190509903917945L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190509903917948L);

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Inventory", "Name", "NumMenu", "OrderId", "Price" },
                values: new object[,]
                {
                    { 637190552094955481L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 30, "SMALL HAWAIIAN PIZZA", 1, null, 5.00m },
                    { 637190552094956851L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 18, "MEDIUM HAWAIIAN PIZZA", 2, null, 9.50m },
                    { 637190552094956898L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 12, "LARGE HAWAIIAN PIZZA", 3, null, 13.90m },
                    { 637190552094956900L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 24, "SMALL EXQUISITE PIZZA", 4, null, 6.00m },
                    { 637190552094956903L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 30, "MEDIUM EXQUISITE PIZZA", 5, null, 11.00m },
                    { 637190552094956906L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 17, "LARGE EXQUISITE PIZZA", 6, null, 15.50m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 637190552094902343L, "Cooper 786", "MammaMía", 1, "13131" },
                    { 637190552094902839L, "Mitchel 83", "DiegoPizza", 2, "58585" },
                    { 637190552094902863L, "Mesquite 476", "MyPizza", 3, "lolol" },
                    { 637190552094902865L, "Abram 34", "TuPizza", 4, "trole" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 637190552094865165L, "Central 960", "BiancaVisconti", "12345" },
                    { 637190552094886422L, "Street 4250", "SilvanaRoncagliolo", "67890" },
                    { 637190552094886461L, "Calle 13", "JuanitoPerez", "asasa" },
                    { 637190552094886464L, "Avenida 89", "MariaSoto", "trebol" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094955481L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094956851L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094956898L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094956900L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094956903L);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 637190552094956906L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190552094902343L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190552094902839L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190552094902863L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637190552094902865L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190552094865165L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190552094886422L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190552094886461L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 637190552094886464L);

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Inventory", "Name", "NumMenu", "OrderId", "Price" },
                values: new object[,]
                {
                    { 637190509903986496L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 30, "SMALL HAWAIIAN PIZZA", 1, null, 5.00m },
                    { 637190509903988114L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 18, "MEDIUM HAWAIIAN PIZZA", 2, null, 9.50m },
                    { 637190509903988171L, "tomato sauce, vegan mozzarella, pineapple, green pepper, onions", 12, "LARGE HAWAIIAN PIZZA", 3, null, 13.90m },
                    { 637190509903988174L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 24, "SMALL EXQUISITE PIZZA", 4, null, 6.00m },
                    { 637190509903988176L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 30, "MEDIUM EXQUISITE PIZZA", 5, null, 11.00m },
                    { 637190509903988178L, "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions", 17, "LARGE EXQUISITE PIZZA", 6, null, 15.50m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "NumMenu", "Password" },
                values: new object[,]
                {
                    { 637190509903933334L, "Cooper 786", "Mamma Mía", 1, "13131" },
                    { 637190509903933840L, "Mitchel 83", "Diego Pizza", 2, "58585" },
                    { 637190509903933865L, "Mesquite 476", "My Pizza", 3, "lolol" },
                    { 637190509903933867L, "Abram 34", "Tu Pizza", 4, "trole" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 637190509903896366L, "Central 960", "BiancaVisconti", "12345" },
                    { 637190509903917904L, "Street 4250", "SilvanaRoncagliolo", "67890" },
                    { 637190509903917945L, "Calle 13", "JuanitoPerez", "asasa" },
                    { 637190509903917948L, "Avenida 89", "MariaSoto", "trebol" }
                });
        }
    }
}

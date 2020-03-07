using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 1L,
                columns: new[] { "Name", "Password" },
                values: new object[] { "PizzaEater", "eater" });

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 2L,
                column: "Password",
                value: "diego");

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 3L,
                column: "Password",
                value: "pizza");

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 4L,
                column: "Password",
                value: "pizza");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "Name",
                value: "Bianca");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Name",
                value: "Silvana");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3L,
                column: "Name",
                value: "Macarena");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4L,
                column: "Name",
                value: "Victoria");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7L,
                column: "Name",
                value: "Jenny");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 1L,
                columns: new[] { "Name", "Password" },
                values: new object[] { "MammaMia", "13131" });

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 2L,
                column: "Password",
                value: "58585");

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 3L,
                column: "Password",
                value: "lolol");

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 4L,
                column: "Password",
                value: "trole");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "Name",
                value: "BiancaVisconti");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Name",
                value: "SilvanaRoncagliolo");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3L,
                column: "Name",
                value: "MacarenaRodriguez");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4L,
                column: "Name",
                value: "VictoriaTorres");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7L,
                column: "Name",
                value: "JennyLoe");
        }
    }
}

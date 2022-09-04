using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Article", "Author", "Count", "DeleteDateTime", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("c5508b04-e321-4345-aaac-ffc55f981e9c"), "123", "Роберт Мартин", 1, null, "Чистый код. Создание, анализ и рефакторинг", 2020 },
                    { new Guid("9db23f42-f970-4493-96d4-f66ba27454a9"), "124", "Кнут, Дональд Эрвин", 2, null, "Искусство программирования", 2020 },
                    { new Guid("d6b60b8e-3110-4009-bc3a-3aa046e76591"), "125", "Маринина", 200, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Детектив про детектива", 2020 },
                    { new Guid("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"), "126", "Erich Gamma", 1, null, "Gangs of Four (GoF) Design Patterns", 2020 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9db23f42-f970-4493-96d4-f66ba27454a9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c5508b04-e321-4345-aaac-ffc55f981e9c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d6b60b8e-3110-4009-bc3a-3aa046e76591"));
        }
    }
}

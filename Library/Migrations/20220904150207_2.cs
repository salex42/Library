using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "Birthday", "DeleteDateTime", "Fio" },
                values: new object[,]
                {
                    { new Guid("39f7f096-bb97-45ca-91d5-8b53bedc1d56"), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Иванов И.И." },
                    { new Guid("d117ab3b-c26a-4175-8ef9-04943540f4c6"), new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Петров П.П." }
                });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "BookId", "GiveDateTime", "ReaderId", "TakeDateTime" },
                values: new object[,]
                {
                    { new Guid("03f98c08-4df2-4d91-bec8-731820e85750"), new Guid("d6b60b8e-3110-4009-bc3a-3aa046e76591"), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39f7f096-bb97-45ca-91d5-8b53bedc1d56"), new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b80c57f-327c-4702-85da-3bcdc31513b7"), new Guid("9db23f42-f970-4493-96d4-f66ba27454a9"), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39f7f096-bb97-45ca-91d5-8b53bedc1d56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89b9b80f-3ff2-42e7-89ae-36128d2c40b3"), new Guid("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"), new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d117ab3b-c26a-4175-8ef9-04943540f4c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("03f98c08-4df2-4d91-bec8-731820e85750"));

            migrationBuilder.DeleteData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("89b9b80f-3ff2-42e7-89ae-36128d2c40b3"));

            migrationBuilder.DeleteData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("8b80c57f-327c-4702-85da-3bcdc31513b7"));

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: new Guid("39f7f096-bb97-45ca-91d5-8b53bedc1d56"));

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: new Guid("d117ab3b-c26a-4175-8ef9-04943540f4c6"));
        }
    }
}

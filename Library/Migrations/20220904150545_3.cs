using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("03f98c08-4df2-4d91-bec8-731820e85750"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("89b9b80f-3ff2-42e7-89ae-36128d2c40b3"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { null, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("8b80c57f-327c-4702-85da-3bcdc31513b7"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { null, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("03f98c08-4df2-4d91-bec8-731820e85750"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("89b9b80f-3ff2-42e7-89ae-36128d2c40b3"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registers",
                keyColumn: "Id",
                keyValue: new Guid("8b80c57f-327c-4702-85da-3bcdc31513b7"),
                columns: new[] { "GiveDateTime", "TakeDateTime" },
                values: new object[] { new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

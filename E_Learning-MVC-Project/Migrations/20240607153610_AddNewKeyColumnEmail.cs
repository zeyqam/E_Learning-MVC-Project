using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_MVC_Project.Migrations
{
    public partial class AddNewKeyColumnEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 36, 10, 137, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 36, 10, 137, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 36, 10, 137, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "SofDeleted", "Value" },
                values: new object[] { 4, new DateTime(2024, 6, 7, 19, 36, 10, 137, DateTimeKind.Local).AddTicks(8786), "Email", false, "zegamda.code.edu.az" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 18, 57, 12, 144, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 18, 57, 12, 144, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 18, 57, 12, 144, DateTimeKind.Local).AddTicks(9187));
        }
    }
}

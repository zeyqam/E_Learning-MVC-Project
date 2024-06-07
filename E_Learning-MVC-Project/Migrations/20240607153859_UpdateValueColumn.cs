using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_MVC_Project.Migrations
{
    public partial class UpdateValueColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 38, 58, 795, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 38, 58, 795, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 7, 19, 38, 58, 795, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Value" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 38, 58, 795, DateTimeKind.Local).AddTicks(6129), "zegamda@code.edu.az" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Value" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 36, 10, 137, DateTimeKind.Local).AddTicks(8786), "zegamda.code.edu.az" });
        }
    }
}

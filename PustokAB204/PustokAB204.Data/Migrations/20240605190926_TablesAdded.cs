using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokAB204.Data.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 5, 23, 9, 26, 411, DateTimeKind.Utc).AddTicks(8152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 5, 16, 2, 22, 885, DateTimeKind.Utc).AddTicks(1969));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 5, 16, 2, 22, 885, DateTimeKind.Utc).AddTicks(1969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 5, 23, 9, 26, 411, DateTimeKind.Utc).AddTicks(8152));
        }
    }
}

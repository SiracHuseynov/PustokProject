using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokAB204.Data.Migrations
{
    public partial class CostPriceColumnAddedIntoBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 6, 5, 15, 45, 36, 937, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 5, 15, 45, 36, 937, DateTimeKind.Utc).AddTicks(8405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 5, 16, 2, 22, 885, DateTimeKind.Utc).AddTicks(1969));
        }
    }
}

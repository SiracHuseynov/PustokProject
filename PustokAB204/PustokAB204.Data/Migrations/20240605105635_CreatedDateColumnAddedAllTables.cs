using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokAB204.Data.Migrations
{
    public partial class CreatedDateColumnAddedAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");
        }
    }
}

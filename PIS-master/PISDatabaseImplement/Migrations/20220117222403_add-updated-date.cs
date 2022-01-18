using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PISDatabaseImplement.Migrations
{
    public partial class addupdateddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InteresUpdateDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InteresUpdateDate",
                table: "Books");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam_My_Example.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spravochnik1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fio = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spravochnik1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spravochnik2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fio = table.Column<string>(nullable: true),
                    Otdelenie = table.Column<string>(nullable: true),
                    Doljnost = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spravochnik2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TypePriema = table.Column<int>(nullable: false),
                    Spravochnik2Id = table.Column<int>(nullable: false),
                    Spravochnik1Id = table.Column<int>(nullable: false),
                    Jalobi = table.Column<string>(nullable: true),
                    Diagnoz = table.Column<string>(nullable: true),
                    Naznachenia = table.Column<string>(nullable: true),
                    DateVizdorovlenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document1s_Spravochnik1s_Spravochnik1Id",
                        column: x => x.Spravochnik1Id,
                        principalTable: "Spravochnik1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document1s_Spravochnik2s_Spravochnik2Id",
                        column: x => x.Spravochnik2Id,
                        principalTable: "Spravochnik2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document1s_Spravochnik1Id",
                table: "Document1s",
                column: "Spravochnik1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Document1s_Spravochnik2Id",
                table: "Document1s",
                column: "Spravochnik2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document1s");

            migrationBuilder.DropTable(
                name: "Spravochnik1s");

            migrationBuilder.DropTable(
                name: "Spravochnik2s");
        }
    }
}

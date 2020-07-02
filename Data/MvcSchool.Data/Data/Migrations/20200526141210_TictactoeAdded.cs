using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcSchool.Data.Data.Migrations
{
    public partial class TictactoeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tictactoe",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    DateTimeFinished = table.Column<DateTime>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    IdAspNetUser1 = table.Column<string>(nullable: true),
                    IdAspNetUser2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tictactoe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tictactoe");
        }
    }
}

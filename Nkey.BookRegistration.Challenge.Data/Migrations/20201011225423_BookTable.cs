using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nkey.BookRegistration.Challenge.Data.Migrations
{
    public partial class BookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    author = table.Column<string>(nullable: false),
                    isbn = table.Column<string>(nullable: false),
                    release_year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("book_id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}

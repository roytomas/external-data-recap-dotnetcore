using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixerMovie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    original_title = table.Column<string>(nullable: true),
                    imdb_id = table.Column<string>(nullable: true),
                    release_date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    popularity = table.Column<double>(nullable: false),
                    poster_path = table.Column<string>(nullable: true),
                    revenue = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    runtime = table.Column<int>(nullable: false),
                    overview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}

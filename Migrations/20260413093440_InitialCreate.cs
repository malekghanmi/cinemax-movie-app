using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppMovie.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Director = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    PosterUrl = table.Column<string>(type: "TEXT", nullable: true),
                    TrailerUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Cast = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Language = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Cast", "CreatedAt", "Description", "Director", "Duration", "Genre", "Language", "PosterUrl", "Price", "Rating", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(888), "Un voleur qui s'infiltre dans les rêves des gens pour extraire des informations précieuses se voit offrir une chance de retrouver sa vie passée en échange d'une tâche apparemment impossible.", "Christopher Nolan", 148, "Science-Fiction", "Anglais", "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg", 9.99m, 8.8000000000000007, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", "https://www.youtube.com/embed/YoHD9XEInc0" },
                    { 2, "Matthew McConaughey, Anne Hathaway, Jessica Chastain", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(925), "Une équipe d'explorateurs voyage à travers un trou de ver dans l'espace dans une tentative pour assurer la survie de l'humanité.", "Christopher Nolan", 169, "Science-Fiction", "Anglais", "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lZmoaApkNFVb.jpg", 9.99m, 8.5999999999999996, new DateTime(2014, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar", "https://www.youtube.com/embed/zSWdZVtXT7E" },
                    { 3, "Christian Bale, Heath Ledger, Aaron Eckhart", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(930), "Batman élève sa guerre contre le crime à un nouveau niveau alors qu'il cherche à démanteler le crime organisé à Gotham.", "Christopher Nolan", 152, "Action", "Anglais", "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg", 8.99m, 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", "https://www.youtube.com/embed/EXeTwQWrcwY" },
                    { 4, "John Travolta, Uma Thurman, Samuel L. Jackson", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(934), "Les vies de deux tueurs à gages, d'un boxeur, d'un gangster et de sa femme, et d'une paire de bandits se croisent dans quatre histoires de violence et de rédemption.", "Quentin Tarantino", 154, "Crime", "Anglais", "https://image.tmdb.org/t/p/w500/fIE3lAGcZDV1G6XM5KmuWnNsPp1.jpg", 7.99m, 8.9000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction", "https://www.youtube.com/embed/s7EdQ4FqbhY" },
                    { 5, "Sam Worthington, Zoe Saldana, Sigourney Weaver", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(938), "Un marine paraplégique est envoyé sur la lune Pandora en mission, mais il se retrouve déchiré entre les ordres de sa mission et la protection du monde qu'il commence à aimer.", "James Cameron", 162, "Science-Fiction", "Anglais", "https://image.tmdb.org/t/p/w500/jRXYjXNq0Cs2TcJjLkki24MLp7u.jpg", 10.99m, 7.7999999999999998, new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar", "https://www.youtube.com/embed/5PSNL1qE6VY" },
                    { 6, "Song Kang-ho, Lee Sun-kyun, Cho Yeo-jeong", new DateTime(2026, 4, 13, 9, 34, 40, 67, DateTimeKind.Utc).AddTicks(942), "La famille pauvre de Ki-taek s'intéresse à la riche famille Park et commence à s'infiltrer dans leur ménage en se faisant passer pour des travailleurs non liés.", "Bong Joon-ho", 132, "Thriller", "Coréen", "https://image.tmdb.org/t/p/w500/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg", 9.99m, 8.5, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parasite", "https://www.youtube.com/embed/5xH0HfJHsaY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}

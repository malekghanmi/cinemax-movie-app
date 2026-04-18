using Microsoft.EntityFrameworkCore;
using AppMovie.Models;

namespace AppMovie.Data;

public class AppmovieContext : DbContext
{
    public AppmovieContext(DbContextOptions<AppmovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data - films populaires
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Inception",
                ReleaseDate = new DateTime(2010, 7, 16),
                Genre = "Science-Fiction",
                Price = 9.99m,
                Description = "Un voleur qui s'infiltre dans les rêves des gens pour extraire des informations précieuses se voit offrir une chance de retrouver sa vie passée en échange d'une tâche apparemment impossible.",
                Director = "Christopher Nolan",
                Duration = 148,
                Rating = 8.8,
                PosterUrl = "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                TrailerUrl = "https://www.youtube.com/embed/YoHD9XEInc0",
                Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page",
                Language = "Anglais",
                CreatedAt = DateTime.UtcNow
            },
            new Movie
            {
                Id = 2,
                Title = "Interstellar",
                ReleaseDate = new DateTime(2014, 11, 5),
                Genre = "Science-Fiction",
                Price = 9.99m,
                Description = "Une équipe d'explorateurs voyage à travers un trou de ver dans l'espace dans une tentative pour assurer la survie de l'humanité.",
                Director = "Christopher Nolan",
                Duration = 169,
                Rating = 8.6,
                PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lZmoaApkNFVb.jpg",
                TrailerUrl = "https://www.youtube.com/embed/zSWdZVtXT7E",
                Cast = "Matthew McConaughey, Anne Hathaway, Jessica Chastain",
                Language = "Anglais",
                CreatedAt = DateTime.UtcNow
            },
            new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                ReleaseDate = new DateTime(2008, 7, 18),
                Genre = "Action",
                Price = 8.99m,
                Description = "Batman élève sa guerre contre le crime à un nouveau niveau alors qu'il cherche à démanteler le crime organisé à Gotham.",
                Director = "Christopher Nolan",
                Duration = 152,
                Rating = 9.0,
                PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                TrailerUrl = "https://www.youtube.com/embed/EXeTwQWrcwY",
                Cast = "Christian Bale, Heath Ledger, Aaron Eckhart",
                Language = "Anglais",
                CreatedAt = DateTime.UtcNow
            },
            new Movie
            {
                Id = 4,
                Title = "Pulp Fiction",
                ReleaseDate = new DateTime(1994, 10, 14),
                Genre = "Crime",
                Price = 7.99m,
                Description = "Les vies de deux tueurs à gages, d'un boxeur, d'un gangster et de sa femme, et d'une paire de bandits se croisent dans quatre histoires de violence et de rédemption.",
                Director = "Quentin Tarantino",
                Duration = 154,
                Rating = 8.9,
                PosterUrl = "https://image.tmdb.org/t/p/w500/fIE3lAGcZDV1G6XM5KmuWnNsPp1.jpg",
                TrailerUrl = "https://www.youtube.com/embed/s7EdQ4FqbhY",
                Cast = "John Travolta, Uma Thurman, Samuel L. Jackson",
                Language = "Anglais",
                CreatedAt = DateTime.UtcNow
            },
            new Movie
            {
                Id = 5,
                Title = "Avatar",
                ReleaseDate = new DateTime(2009, 12, 18),
                Genre = "Science-Fiction",
                Price = 10.99m,
                Description = "Un marine paraplégique est envoyé sur la lune Pandora en mission, mais il se retrouve déchiré entre les ordres de sa mission et la protection du monde qu'il commence à aimer.",
                Director = "James Cameron",
                Duration = 162,
                Rating = 7.8,
                PosterUrl = "https://image.tmdb.org/t/p/w500/jRXYjXNq0Cs2TcJjLkki24MLp7u.jpg",
                TrailerUrl = "https://www.youtube.com/embed/5PSNL1qE6VY",
                Cast = "Sam Worthington, Zoe Saldana, Sigourney Weaver",
                Language = "Anglais",
                CreatedAt = DateTime.UtcNow
            },
            new Movie
            {
                Id = 6,
                Title = "Parasite",
                ReleaseDate = new DateTime(2019, 10, 11),
                Genre = "Thriller",
                Price = 9.99m,
                Description = "La famille pauvre de Ki-taek s'intéresse à la riche famille Park et commence à s'infiltrer dans leur ménage en se faisant passer pour des travailleurs non liés.",
                Director = "Bong Joon-ho",
                Duration = 132,
                Rating = 8.5,
                PosterUrl = "https://image.tmdb.org/t/p/w500/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg",
                TrailerUrl = "https://www.youtube.com/embed/5xH0HfJHsaY",
                Cast = "Song Kang-ho, Lee Sun-kyun, Cho Yeo-jeong",
                Language = "Coréen",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}

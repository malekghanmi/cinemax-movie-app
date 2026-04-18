using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppMovie.Data;
using AppMovie.Models;

namespace AppMovie.Controllers;

public class MoviesController : Controller
{
    private readonly AppmovieContext _context;
    private readonly IWebHostEnvironment _env;

    public MoviesController(AppmovieContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // GET: Movies
    public async Task<IActionResult> Index(string? searchString, string? genre, string? sortOrder, int? year)
    {
        ViewData["TitleSort"] = sortOrder == "title" ? "title_desc" : "title";
        ViewData["DateSort"] = sortOrder == "date" ? "date_desc" : "date";
        ViewData["RatingSort"] = sortOrder == "rating" ? "rating_desc" : "rating";
        ViewData["CurrentFilter"] = searchString;
        ViewData["CurrentGenre"] = genre;
        ViewData["CurrentYear"] = year;

        var movies = _context.Movie.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(m =>
                m.Title.Contains(searchString) ||
                (m.Director != null && m.Director.Contains(searchString)) ||
                (m.Cast != null && m.Cast.Contains(searchString)) ||
                (m.Description != null && m.Description.Contains(searchString)));
        }

        if (!string.IsNullOrEmpty(genre))
            movies = movies.Where(m => m.Genre == genre);

        if (year.HasValue)
            movies = movies.Where(m => m.ReleaseDate.Year == year.Value);

        movies = sortOrder switch
        {
            "title" => movies.OrderBy(m => m.Title),
            "title_desc" => movies.OrderByDescending(m => m.Title),
            "date" => movies.OrderBy(m => m.ReleaseDate),
            "date_desc" => movies.OrderByDescending(m => m.ReleaseDate),
            "rating" => movies.OrderBy(m => m.Rating),
            "rating_desc" => movies.OrderByDescending(m => m.Rating),
            _ => movies.OrderByDescending(m => m.CreatedAt)
        };

        // Genres for filter
        ViewBag.Genres = await _context.Movie
            .Where(m => m.Genre != null)
            .Select(m => m.Genre!)
            .Distinct()
            .OrderBy(g => g)
            .ToListAsync();

        ViewBag.Years = await _context.Movie
            .Select(m => m.ReleaseDate.Year)
            .Distinct()
            .OrderByDescending(y => y)
            .ToListAsync();

        return View(await movies.ToListAsync());
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();

        // Related movies same genre
        ViewBag.Related = await _context.Movie
            .Where(m => m.Genre == movie.Genre && m.Id != movie.Id)
            .Take(4)
            .ToListAsync();

        return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        ViewBag.Genres = GetGenres();
        return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price,Description,Director,Duration,Rating,PosterUrl,TrailerUrl,Cast,Language")] Movie movie, IFormFile? posterFile)
    {
        if (posterFile != null && posterFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);
            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(posterFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await posterFile.CopyToAsync(stream);
            movie.PosterUrl = "/uploads/" + uniqueFileName;
        }

        if (ModelState.IsValid)
        {
            movie.CreatedAt = DateTime.UtcNow;
            _context.Add(movie);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"« {movie.Title} » a été ajouté avec succès !";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Genres = GetGenres();
        return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var movie = await _context.Movie.FindAsync(id);
        if (movie == null) return NotFound();
        ViewBag.Genres = GetGenres();
        return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Description,Director,Duration,Rating,PosterUrl,TrailerUrl,Cast,Language,CreatedAt")] Movie movie, IFormFile? posterFile)
    {
        if (id != movie.Id) return NotFound();

        if (posterFile != null && posterFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);
            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(posterFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await posterFile.CopyToAsync(stream);
            movie.PosterUrl = "/uploads/" + uniqueFileName;
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"« {movie.Title} » a été modifié avec succès !";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Genres = GetGenres();
        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movie.FindAsync(id);
        if (movie != null)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Le film a été supprimé.";
        }
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int id) => _context.Movie.Any(e => e.Id == id);

    private static List<string> GetGenres() => new()
    {
        "Action", "Animation", "Aventure", "Biographie", "Comédie",
        "Crime", "Documentaire", "Drame", "Fantaisie", "Horreur",
        "Musical", "Mystère", "Romance", "Science-Fiction", "Thriller", "Western"
    };
}

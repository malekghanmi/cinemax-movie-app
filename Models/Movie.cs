using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le titre est obligatoire")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Date de sortie")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [StringLength(100)]
    public string? Genre { get; set; }

    [DataType(DataType.Currency)]
    [Range(0, 1000)]
    public decimal Price { get; set; }

    [StringLength(2000)]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Réalisateur")]
    [StringLength(200)]
    public string? Director { get; set; }

    [Display(Name = "Durée (min)")]
    public int? Duration { get; set; }

    [Display(Name = "Note (0-10)")]
    [Range(0, 10)]
    public double? Rating { get; set; }

    [Display(Name = "Affiche du film")]
    public string? PosterUrl { get; set; }

    [Display(Name = "Bande-annonce (URL YouTube)")]
    public string? TrailerUrl { get; set; }

    [Display(Name = "Casting")]
    [StringLength(500)]
    public string? Cast { get; set; }

    [Display(Name = "Langue")]
    [StringLength(50)]
    public string? Language { get; set; } = "Français";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

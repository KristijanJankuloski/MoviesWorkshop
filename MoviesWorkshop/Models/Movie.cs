using MoviesWorkshop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesWorkshop.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        [MaxLength(127)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public MovieGenre Genre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MoviesWorkshop.DTOs
{
    public class MovieCreateDto
    {
        [Required]
        [MaxLength(127)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Range(1, 21)]
        public int Genre { get; set; }
    }
}

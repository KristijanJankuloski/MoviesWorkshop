using System.ComponentModel.DataAnnotations;

namespace MoviesWorkshop.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(127)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Range(1, 21)]
        public int Genre { get; set; }
    }
}

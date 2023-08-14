using MoviesWorkshop.DTOs;
using MoviesWorkshop.Models;
using MoviesWorkshop.Models.Enums;

namespace MoviesWorkshop.Mappers
{
    public static class MovieMappers
    {
        public static MovieListDto ToMovieListDto(this Movie movie)
        {
            return new MovieListDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre.ToString(),
                Year = movie.Year,
            };
        }
        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description != null ? movie.Description : "No description",
                Year = movie.Year,
                Genre = (int)movie.Genre,
            };
        }

        public static Movie ToMovie(this MovieCreateDto dto)
        {
            return new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year,
                Genre = (MovieGenre)dto.Genre
            };
        }

        public static Movie ToMovie(this MovieUpdateDto dto)
        {
            return new Movie
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year,
                Genre = (MovieGenre)dto.Genre
            };
        }
    }
}

using MoviesWorkshop.Models;
using MoviesWorkshop.Models.Enums;

namespace MoviesWorkshop.Data.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<List<Movie>> GetByGenre(MovieGenre genre);
        Task InsertAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteByIdAsync(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using MoviesWorkshop.Data.Context;
using MoviesWorkshop.Models;
using MoviesWorkshop.Models.Enums;

namespace MoviesWorkshop.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppContext _context;
        public MovieRepository(MovieAppContext context)
        {
            _context = context;
        }
        public async Task DeleteByIdAsync(int id)
        {
            Movie movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return;
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>> GetByGenre(MovieGenre genre)
        {
            return await _context.Movies.Where(m => m.Genre == genre).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task InsertAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}

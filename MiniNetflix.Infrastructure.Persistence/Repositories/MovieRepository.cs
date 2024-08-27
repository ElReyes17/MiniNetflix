
using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class MovieRepository(ApplicationContext dbContext) : BaseRepository<Movie>(dbContext), IMovieRepository 
    {
        public async Task<bool> isExist(int id)
        {
            return await dbContext.Movie.AnyAsync(g => g.MovieId == id);
        }

        public async Task<List<Movie>> GetAllWithIncludeAsync()
        {
           return await dbContext.Movie.Include(m => m.MovieGenres)
                                       .ThenInclude(mv => mv.Genre)
                                       .Include(m => m.Producer)
                                       .ToListAsync();
        }

        public async Task<Movie> FindByIdIncludeAsync(int id) 
        {
          
             var movie = await dbContext.Movie.Include(m => m.MovieGenres)
                                        .ThenInclude(mv => mv.Genre)
                                        .Include(m => m.Producer)
                                        .FirstOrDefaultAsync(m => m.MovieId == id);


            return movie;
        }
    }
    
}

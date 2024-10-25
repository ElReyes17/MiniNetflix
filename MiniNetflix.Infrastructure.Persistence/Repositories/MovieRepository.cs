using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

#nullable disable

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository 
    {
        private readonly ApplicationContext _dbContext;
        public MovieRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsExist(int id) => await _dbContext.Movie.AnyAsync(g => g.MovieId == id);  
        public async Task<List<Movie>> GetAllWithIncludeAsync() => await _dbContext.Movie.Include(m => m.MovieGenres)
                                                                                         .ThenInclude(mv => mv.Genre)
                                                                                         .Include(m => m.Producer)
                                                                                         .ToListAsync();
        public async Task<Movie> FindByIdIncludeAsync(int id) => await _dbContext.Movie.Include(m => m.MovieGenres)
                                                                                       .ThenInclude(mv => mv.Genre)
                                                                                       .Include(m => m.Producer)
                                                                                       .FirstOrDefaultAsync(m => m.MovieId == id);

    }
    
}

using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class MovieGenreRepository : BaseRepository<MovieGenre>, IMovieGenreRepository 
    {
        private readonly ApplicationContext _dbContext;
        public MovieGenreRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
   

}


using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class MovieRepository(ApplicationContext dbContext) : BaseRepository<Movie>(dbContext), IMovieRepository { }
    
}

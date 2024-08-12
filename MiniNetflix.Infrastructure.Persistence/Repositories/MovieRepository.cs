
using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Core.Domain.Entities;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Repositories
{
    public class MovieRepository(ApplicationContext dbContext) : BaseRepository<Movie>(dbContext), IMovieRepository { }
    
}

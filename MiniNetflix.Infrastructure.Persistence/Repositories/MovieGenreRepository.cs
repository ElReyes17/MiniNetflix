using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Core.Domain.Entities;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Repositories
{
    public class MovieGenreRepository(ApplicationContext dbContext) : BaseRepository<MovieGenre>(dbContext), IMovieGenreRepository { }
   
}

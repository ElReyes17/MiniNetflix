using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Core.Domain.Entities;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Repositories
{
    public class GenreRepository(ApplicationContext dbContext) : BaseRepository<Genre>(dbContext), IGenreRepository { }
    
}

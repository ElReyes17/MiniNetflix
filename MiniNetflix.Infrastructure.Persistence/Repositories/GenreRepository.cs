using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class GenreRepository(ApplicationContext dbContext) : BaseRepository<Genre>(dbContext), IGenreRepository 
    {

        public async Task<bool> isExist(int id)
        {
            return await dbContext.Genre.AnyAsync(g => g.GenreId == id);
        }

    }
    
}

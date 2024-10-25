using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository 
    {
        private readonly ApplicationContext _dbContext;
        public GenreRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsExist(int id) => await _dbContext.Genre.AnyAsync(g => g.GenreId == id);
       
    }
    
}

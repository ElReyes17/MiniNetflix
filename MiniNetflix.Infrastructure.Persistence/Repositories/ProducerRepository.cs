using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository 
    {
        private readonly ApplicationContext _dbContext;
        public ProducerRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsExist(int id) => await _dbContext.Producer.AnyAsync(g => g.ProducerId == id);

    }
    
}

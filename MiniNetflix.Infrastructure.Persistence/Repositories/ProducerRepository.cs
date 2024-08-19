using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Entities;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class ProducerRepository(ApplicationContext dbContext) : BaseRepository<Producer>(dbContext), IProducerRepository 
    {
        public async Task<bool> isExist(int id)
        {
            return await dbContext.Producer.AnyAsync(g => g.ProducerId == id);
        }
    }
    
}

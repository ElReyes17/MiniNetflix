using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Core.Domain.Entities;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Repositories
{
    public class ProducerRepository(ApplicationContext dbContext) : BaseRepository<Producer>(dbContext), IProducerRepository { }
    
}

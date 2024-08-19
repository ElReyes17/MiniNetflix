using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Interfaces.Repositories
{
    public interface IProducerRepository : IBaseRepository<Producer> 
    {
        Task<bool> isExist(int id);
    }
    
}

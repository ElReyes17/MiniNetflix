using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Core.Application.Interfaces.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre> 
    {
        Task<bool> IsExist(int id);
    }
    
}

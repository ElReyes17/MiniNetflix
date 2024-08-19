using MiniNetflix.Core.Domain.Entities;


namespace MiniNetflix.Core.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie> 
    {
        Task<bool> isExist(int id);
    }
    
}

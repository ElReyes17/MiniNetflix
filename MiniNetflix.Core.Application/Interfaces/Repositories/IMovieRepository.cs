using MiniNetflix.Core.Domain.Entities;


namespace MiniNetflix.Core.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie> 
    {
        Task<bool> isExist(int id);

        Task<List<Movie>> GetAllWithIncludeAsync();

        Task<Movie> FindByIdIncludeAsync(int id);
    }
    
}

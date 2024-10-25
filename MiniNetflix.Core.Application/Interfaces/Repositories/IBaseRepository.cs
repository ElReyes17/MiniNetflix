
namespace MiniNetflix.Core.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity, int id);
        void Delete(T entity);
    }
}

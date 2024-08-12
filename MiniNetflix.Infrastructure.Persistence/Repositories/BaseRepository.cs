

using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Common;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T>(ApplicationContext context) : IBaseRepository<T> where T : BaseEntity
    {

        public async Task<List<T>> GetAllAsync() => await context.Set<T>().ToListAsync();
       
        public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

        public void Add(T entity) =>  context.Set<T>().AddAsync(entity);
        
        public void Update(T entity) =>  context.Set<T>().Update(entity);

        public void Delete(T entity) 
        {
            entity.IsDeleted = true;
            Update(entity);
        } 
        
    }
}

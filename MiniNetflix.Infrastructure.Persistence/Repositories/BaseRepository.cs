

using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Application.Interfaces.Repositories;
using MiniNetflix.Core.Domain.Common;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T>(ApplicationContext context) : IBaseRepository<T> where T : BaseEntity
    {
        public async Task<List<T>> GetAllAsync() => await context.Set<T>().ToListAsync();  
        public async Task<T?> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);
        public void Add(T entity) => context.Set<T>().Add(entity);       
        public void Update(T entity, int id)
        {
            var getEntityById =  context.Set<T>().Find(id);         
            if (getEntityById != null) context.Set<T>().Entry(getEntityById).CurrentValues.SetValues(entity);

        }  
        public void Delete(T entity) 
        {
            entity.IsDeleted = true;
            context.Set<T>().Update(entity);
        } 
        
    }
}

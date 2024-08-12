

using Microsoft.EntityFrameworkCore;
using PruebaMinimalAPI.Core.Application.Interfaces.Repositories;
using PruebaMinimalAPI.Core.Domain.Common;
using PruebaMinimalAPI.Infrastructure.Persistence.Context;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Repositories
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

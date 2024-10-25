

using MiniNetflix.Core.Application.Interfaces.UnitOfWork;
using MiniNetflix.Infrastructure.Persistence.Context;

namespace MiniNetflix.Infrastructure.Persistence
{
    public class UnitOfWork(ApplicationContext dbContext) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await dbContext.SaveChangesAsync(cancellationToken);
    
    }
}

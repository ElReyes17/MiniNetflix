
namespace MiniNetflix.Core.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}

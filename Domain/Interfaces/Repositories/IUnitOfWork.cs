using Domain.Entities.Base;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
        void Save();
    }
}

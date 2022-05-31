using Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void Create(TEntity entity);

        Guid CreateWithVal(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SoftDelete(Guid id);
        void Detach(TEntity entity);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        IEnumerable<TEntity> FindWithDeleted(Expression<Func<TEntity, bool>> predicate,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        IEnumerable<TEntity> GetAllWithDeleted(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}

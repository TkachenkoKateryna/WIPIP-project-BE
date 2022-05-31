using Domain.Models.Entities.Base;
using Domain.Interfaces.Repositories;
using Persistence.EF;
using System.Collections;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Hashtable _repositories = new Hashtable();

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IBaseEntity
        {
            var entityTypeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityTypeName))
            {
                _repositories.Add(entityTypeName, new Repository<TEntity>(_context));
            }

            return (IRepository<TEntity>)_repositories[entityTypeName];
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

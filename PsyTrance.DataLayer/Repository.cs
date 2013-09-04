using System;
using System.Data.Entity;
using System.Linq;

namespace PsyTrance.DataLayer
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository()
        {
            _dbContext = new DbContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Select()
        {
            return _dbSet;
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
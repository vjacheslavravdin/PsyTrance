using System;
using System.Linq;

namespace PsyTrance.DataLayer
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> Select();

        void Insert(TEntity entity);
    }
}
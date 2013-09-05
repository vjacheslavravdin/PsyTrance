using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        List<TEntity> Select();

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OpenLicence.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(Guid id);
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        TEntity One(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Normalize(TEntity entity);
    }
}
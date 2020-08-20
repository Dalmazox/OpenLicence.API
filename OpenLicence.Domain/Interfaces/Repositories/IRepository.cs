using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OpenLicence.Domain.Interfaces.Repositories
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository where T : class
    {
        IEnumerable<T> Get();
        T Get(Guid id);
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
        T One(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
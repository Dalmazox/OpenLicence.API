using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Infra.Data.Context;

namespace OpenLicence.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected OpenLicenceContext _context;
        protected DbSet<T> _db;

        public BaseRepository(OpenLicenceContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _db.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _db.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
            => _db.Where(predicate);

        public virtual IEnumerable<T> Get()
            => _db;

        public virtual T Get(Guid id)
            => _db.Find(id);

        public virtual T One(Expression<Func<T, bool>> predicate)
            => _db.FirstOrDefault(predicate);

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _db.Update(entity);
            _context.SaveChanges();
        }
    }
}
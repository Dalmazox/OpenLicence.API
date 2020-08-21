using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public abstract class BaseService<TEntity, TRepository> : IService<TEntity>
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly IUnitOfWork _uow;
        protected TRepository _repository;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Repository<TRepository>();
        }

        public virtual IEnumerable<TEntity> Get()
            => _repository.Get();

        public virtual TEntity Get(Guid id)
            => _repository.Get(id);

        public virtual IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
            => _repository.Filter(predicate);

        public virtual TEntity One(Expression<Func<TEntity, bool>> predicate)
            => _repository.One(predicate);

        public virtual void Add(TEntity entity)
            => _repository.Add(entity);

        public virtual void Update(TEntity entity)
            => _repository.Update(entity);

        public virtual void Delete(TEntity entity)
            => _repository.Delete(entity);

        public abstract void Normalize(TEntity entity);
    }
}
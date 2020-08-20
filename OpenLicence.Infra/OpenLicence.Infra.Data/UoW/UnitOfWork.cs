using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.UoW;
using OpenLicence.Infra.Data.Context;
using OpenLicence.Infra.Data.Repositories;

namespace OpenLicence.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OpenLicenceContext _context;
        private IDbContextTransaction _transaction { get; set; } = null;
        private IDictionary<Type, Type> _repositories { get; set; }

        public UnitOfWork(OpenLicenceContext context)
        {
            _context = context;

            ConfigureRepositories();
        }

        private void ConfigureRepositories()
        {
            if (_repositories is null)
                _repositories = new Dictionary<Type, Type>();

            _repositories.Add(typeof(IEnterpriseRepository), typeof(EnterpriseRepository));
            _repositories.Add(typeof(ILicenceRepository), typeof(LicenceRepository));
            _repositories.Add(typeof(ISoftwareHouseRepository), typeof(SoftwareHouseRepository));
            _repositories.Add(typeof(ISoftwareRepository), typeof(SoftwareRepository));
        }

        public int SaveChanges() => _context.SaveChanges();

        public void BeginTransaction()
        {
            if (!(_transaction is null))
                return;

            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_transaction is null)
                return;

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                if (_transaction is null)
                    return;

                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public T Repository<T>() where T : IRepository
        {
            var type = _repositories.FirstOrDefault(r => r.Key.Equals(typeof(T))).Value;

            if (type is null) throw new Exception("Repositório não implementado");

            return (T)Activator.CreateInstance(type, new object[] { _context });
        }
    }
}
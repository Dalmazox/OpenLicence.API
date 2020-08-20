using OpenLicence.Domain.Interfaces.Repositories;

namespace OpenLicence.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void BeginTransaction();
        void Rollback();
        void Commit();
        T Repository<T>() where T : IRepository;
    }
}
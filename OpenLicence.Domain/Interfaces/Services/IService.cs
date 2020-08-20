using System.Collections.Generic;

namespace OpenLicence.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
    }
}
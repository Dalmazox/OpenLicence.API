using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public class LicenceService : BaseService<Licence, ILicenceRepository>, ILicenceService
    {
        public LicenceService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public class SoftwareService : BaseService<Software, ISoftwareRepository>, ISoftwareService
    {
        public SoftwareService(IUnitOfWork uow) : base(uow)
        { }

        public override void Normalize(Software entity)
        { }
    }
}
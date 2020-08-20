using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public class SoftwareHouseService : BaseService<SoftwareHouse, ISoftwareHouseRepository>, ISoftwareHouseService
    {
        public SoftwareHouseService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
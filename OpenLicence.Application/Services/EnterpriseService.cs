using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public class EnterpriseService : BaseService<Enterprise, IEnterpriseRepository>, IEnterpriseService
    {
        public EnterpriseService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
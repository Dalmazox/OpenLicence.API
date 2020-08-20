using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Infra.Data.Context;

namespace OpenLicence.Infra.Data.Repositories
{
    public class EnterpriseRepository : BaseRepository<Enterprise>, IEnterpriseRepository
    {
        public EnterpriseRepository(OpenLicenceContext context) : base(context)
        {
        }
    }
}
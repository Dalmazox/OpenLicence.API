using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Infra.Data.Context;

namespace OpenLicence.Infra.Data.Repositories
{
    public class SoftwareRepository : BaseRepository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(OpenLicenceContext context) : base(context)
        {
        }
    }
}
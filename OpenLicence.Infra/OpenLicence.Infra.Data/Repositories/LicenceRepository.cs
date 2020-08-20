using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Infra.Data.Context;

namespace OpenLicence.Infra.Data.Repositories
{
    public class LicenceRepository : BaseRepository<Licence>, ILicenceRepository
    {
        public LicenceRepository(OpenLicenceContext context) : base(context)
        {
        }
    }
}
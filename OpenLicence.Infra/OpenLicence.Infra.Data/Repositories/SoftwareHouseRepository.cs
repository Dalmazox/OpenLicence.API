using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Infra.Data.Context;

namespace OpenLicence.Infra.Data.Repositories
{
    public class SoftwareHouseRepository : BaseRepository<SoftwareHouse>, ISoftwareHouseRepository
    {
        public SoftwareHouseRepository(OpenLicenceContext context) : base(context)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Infra.Data.Mappings
{
    public static class ForeignKeyMaps
    {
        public static void ConfigureForeignKeys(this ModelBuilder builder)
        {
            builder.Entity<Enterprise>()
                .HasMany(e => e.Licences)
                .WithOne(l => l.Enterprise)
                .HasForeignKey(l => l.EnterpriseID);

            builder.Entity<SoftwareHouse>()
                .HasMany(sh => sh.Softwares)
                .WithOne(s => s.SoftwareHouse)
                .HasForeignKey(s => s.SoftwareHouseID);

            builder.Entity<Software>()
                .HasMany(s => s.Licences)
                .WithOne(l => l.Software)
                .HasForeignKey(l => l.SoftwareID);
        }
    }
}
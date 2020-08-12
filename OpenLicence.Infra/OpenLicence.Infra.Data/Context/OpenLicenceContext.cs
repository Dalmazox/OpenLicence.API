using Microsoft.EntityFrameworkCore;
using OpenLicence.Infra.Data.Mappings;

namespace OpenLicence.Infra.Data.Context
{
    public class OpenLicenceContext : DbContext
    {
        public OpenLicenceContext(DbContextOptions<OpenLicenceContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(SoftwareMap).Assembly)
                .ConfigureForeignKeys();

            base.OnModelCreating(modelBuilder);
        }
    }
}
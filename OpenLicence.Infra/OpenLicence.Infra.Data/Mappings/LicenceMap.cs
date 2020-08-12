using System;
using OpenLicence.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenLicence.Infra.Data.Mappings
{
    public class LicenceMap : IEntityTypeConfiguration<Licence>
    {
        public void Configure(EntityTypeBuilder<Licence> builder)
        {
            builder.ToTable("Licences");

            builder.HasIndex(l => new { l.EnterpriseID, l.SoftwareID }).IsUnique();
            builder.HasIndex(l => l.Expires);
            builder.HasIndex(l => l.CreatedAt);

            builder.Property(l => l.Expires).IsRequired();
            builder.Property(l => l.EnterpriseID).IsRequired();
            builder.Property(l => l.SoftwareID).IsRequired();
        }
    }
}
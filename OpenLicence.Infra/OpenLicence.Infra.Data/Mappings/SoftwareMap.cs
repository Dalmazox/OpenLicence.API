using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Infra.Data.Mappings
{
    public class SoftwareMap : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder.ToTable("Softwares");

            builder
                .HasIndex(s => new { s.Name, s.SoftwareHouseID })
                .IsUnique();

            builder.HasIndex(s => s.CreatedAt);

            builder
                .Property(s => s.Name)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();
        }
    }
}
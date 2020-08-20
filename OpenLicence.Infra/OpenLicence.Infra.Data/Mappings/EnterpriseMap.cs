using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Infra.Data.Mappings
{
    public class EnterpriseMap : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.ToTable("Enterprises");

            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.CNPJ).IsUnique();
            builder.HasIndex(e => e.CreatedAt);
            builder.HasIndex(e => e.UpdatedAt);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(e => e.CNPJ)
                .HasColumnType("VARCHAR(14)")
                .IsRequired();
        }
    }
}
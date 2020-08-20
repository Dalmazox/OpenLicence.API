using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Infra.Data.Mappings
{
    public class SoftwareHouseMap : IEntityTypeConfiguration<SoftwareHouse>
    {
        public void Configure(EntityTypeBuilder<SoftwareHouse> builder)
        {
            builder.ToTable("SoftwareHouses");

            builder.HasIndex(sh => sh.Name);
            builder.HasIndex(sh => sh.CNPJ).IsUnique();
            builder.HasIndex(sh => sh.CreatedAt);

            builder
                .Property(sh => sh.Name)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(sh => sh.CNPJ)
                .HasColumnType("VARCHAR(14)")
                .IsRequired();
        }
    }
}
using ITControl.Domain.Units.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Units.EntitiesConfiguration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
        builder.Property(x => x.PostalCode).HasMaxLength(8).IsRequired();
        builder.Property(x => x.StreetName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Neighborhood).HasMaxLength(80).IsRequired();
        builder.Property(x => x.AddressNumber).HasMaxLength(5).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
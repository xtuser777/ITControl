using ITControl.Domain.Supplies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Supplies.EntitiesConfiguration;

public class SupplyConfiguration : IEntityTypeConfiguration<Supply>
{
    public void Configure(EntityTypeBuilder<Supply> builder)
    {
        builder.ToTable("Supplies");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Brand)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(s => s.Model)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(s => s.Type)
            .IsRequired();
        builder.Property(s => s.QuantityInStock)
            .IsRequired();
        builder.Property(s => s.CreatedAt)
            .IsRequired();
        builder.Property(s => s.UpdatedAt)
            .IsRequired();
    }
}

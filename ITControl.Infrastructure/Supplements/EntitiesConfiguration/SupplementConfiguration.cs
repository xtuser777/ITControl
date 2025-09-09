using ITControl.Domain.Supplements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Supplements.EntitiesConfiguration;

public class SupplementConfiguration : IEntityTypeConfiguration<Supplement>
{
    public void Configure(EntityTypeBuilder<Supplement> builder)
    {
        builder.ToTable("Supplements");
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

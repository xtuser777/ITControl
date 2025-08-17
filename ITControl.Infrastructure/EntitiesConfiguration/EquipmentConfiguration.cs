using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Ip).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Mac).HasMaxLength(17).IsRequired();
        builder.Property(x => x.Tag).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x=> x.Rented).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        
        builder.HasIndex(x => x.Ip).IsUnique();
        builder.HasIndex(x => x.Mac).IsUnique();
        builder.HasIndex(x => x.Tag).IsUnique();
        
        builder
            .HasOne(x => x.Contract)
            .WithMany()
            .HasForeignKey(x => x.ContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
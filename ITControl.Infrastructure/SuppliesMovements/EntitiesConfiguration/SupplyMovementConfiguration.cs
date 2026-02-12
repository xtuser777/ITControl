using ITControl.Domain.SuppliesMovements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.SuppliesMovements.EntitiesConfiguration;

public class SupplyMovementConfiguration : IEntityTypeConfiguration<SupplyMovement>
{
    public void Configure(EntityTypeBuilder<SupplyMovement> builder)
    {
        builder.ToTable("SuppliesMovements");
        builder.HasKey(sm => sm.Id);
        builder.Property(sm => sm.Quantity).IsRequired();
        builder.Property(sm => sm.MovementDate).IsRequired();
        builder.Property(sm => sm.Observation).HasMaxLength(255);
        builder.Property(sm => sm.SupplyId).IsRequired();
        builder.Property(sm => sm.UserId).IsRequired();
        builder.Property(sm => sm.UnitId).IsRequired();
        builder.Property(sm => sm.DepartmentId).IsRequired();
        builder.Property(sm => sm.DivisionId).IsRequired(false);
        builder.Property(sm => sm.CreatedAt).IsRequired();
        builder.Property(sm => sm.UpdatedAt).IsRequired();
        builder.HasOne(sm => sm.Supply)
            .WithMany()
            .HasForeignKey(sm => sm.SupplyId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(sm => sm.User)
            .WithMany()
            .HasForeignKey(sm => sm.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(sm => sm.Unit)
            .WithMany()
            .HasForeignKey(sm => sm.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(sm => sm.Department)
            .WithMany()
            .HasForeignKey(sm => sm.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(sm => sm.Division)
            .WithMany()
            .HasForeignKey(sm => sm.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

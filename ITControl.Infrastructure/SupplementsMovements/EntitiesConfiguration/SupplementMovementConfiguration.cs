using ITControl.Domain.SupplementsMovements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.SupplementsMovements.EntitiesConfiguration;

public class SupplementMovementConfiguration : IEntityTypeConfiguration<SupplementMovement>
{
    public void Configure(EntityTypeBuilder<SupplementMovement> builder)
    {
        builder.ToTable("SupplementsMovements");
        builder.HasKey(sm => sm.Id);
        builder.Property(sm => sm.Quantity).IsRequired();
        builder.Property(sm => sm.MovementDate).IsRequired();
        builder.Property(sm => sm.Observation).HasMaxLength(255);
        builder.Property(sm => sm.SupplementId).IsRequired();
        builder.Property(sm => sm.UserId).IsRequired();
        builder.Property(sm => sm.UnitId).IsRequired();
        builder.Property(sm => sm.DepartmentId).IsRequired();
        builder.Property(sm => sm.DivisionId).IsRequired(false);
        builder.Property(sm => sm.CreatedAt).IsRequired();
        builder.Property(sm => sm.UpdatedAt).IsRequired();
        builder.HasOne(sm => sm.Supplement)
            .WithMany()
            .HasForeignKey(sm => sm.SupplementId)
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

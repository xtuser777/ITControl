using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;
public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(t => t.Id);
        builder
            .Property(t => t.Description)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(t => t.Protocol)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(t => t.StartedAt)
            .IsRequired();
        builder
            .Property(t => t.EndedAt);
        builder
            .Property(t => t.StartedIn)
            .IsRequired();
        builder
            .Property(t => t.EndedIn);
        builder
            .Property(t => t.Status)
            .IsRequired();
        builder
            .Property(t => t.Type)
            .IsRequired();
        builder
            .Property(t => t.Observation)
            .HasMaxLength(255)
            .IsRequired();
        builder
            .Property(t => t.ExternalProtocol)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasIndex(t => t.Protocol)
            .IsUnique();

        builder
            .HasOne(t => t.Call)
            .WithMany()
            .HasForeignKey(t => t.CallId)
            .IsRequired();
        builder
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .IsRequired();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class SystemConfiguration : IEntityTypeConfiguration<Domain.Entities.System>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.System> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Version).HasMaxLength(15).IsRequired();
        builder.Property(x => x.ImplementedAt).IsRequired();
        builder.Property(x => x.EndedAt);
        builder.Property(x => x.Own).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        
        builder
            .HasOne(x => x.Contract)
            .WithMany()
            .HasForeignKey(x => x.ContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class CallStatusConfiguration : IEntityTypeConfiguration<CallStatus>
{
    public void Configure(EntityTypeBuilder<CallStatus> builder)
    {
        builder.HasKey(t => t.Id);
        builder
            .Property(p => p.Status)
            .IsRequired();
        builder
            .Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();
        builder
            .Property(x => x.CreatedAt)
            .IsRequired();
        builder
            .Property(x => x.UpdatedAt)
            .IsRequired();

        builder.HasOne(x => x.Call).WithOne("CallStatus")
            .HasForeignKey<CallStatus>(x => x.CallId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}

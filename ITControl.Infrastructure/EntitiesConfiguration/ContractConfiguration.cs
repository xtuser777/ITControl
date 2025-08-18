using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ObjectName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.StartedAt).IsRequired();
        builder.Property(x => x.EndedAt);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);

        builder.HasMany(x => x.ContractContacts).WithOne(x => x.Contract);
    }
}
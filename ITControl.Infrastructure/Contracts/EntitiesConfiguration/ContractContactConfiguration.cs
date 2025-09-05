using ITControl.Domain.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Contracts.EntitiesConfiguration;

public class ContractContactConfiguration : IEntityTypeConfiguration<ContractContact>
{
    public void Configure(EntityTypeBuilder<ContractContact> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Cellphone).HasMaxLength(11).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();

        builder
            .HasOne(x => x.Contract)
            .WithMany(x => x.ContractContacts)
            .HasForeignKey(x => x.ContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
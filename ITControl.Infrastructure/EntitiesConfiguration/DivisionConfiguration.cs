using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class DivisionConfiguration : IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);
        builder.HasOne(x=> x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
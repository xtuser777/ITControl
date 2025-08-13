using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        builder.HasOne(x=> x.Unit).WithMany().HasForeignKey(x => x.UnitId);
        builder.HasOne(x=> x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);
        builder.HasOne(x => x.Division).WithMany().HasForeignKey(x => x.DivisionId);
    }
}
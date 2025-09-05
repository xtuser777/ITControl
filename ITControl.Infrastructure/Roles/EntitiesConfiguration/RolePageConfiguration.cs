using ITControl.Domain.Roles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Roles.EntitiesConfiguration;

public class RolePageConfiguration : IEntityTypeConfiguration<RolePage>
{
    public void Configure(EntityTypeBuilder<RolePage> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasOne(r => r.Role).WithMany(r => r.RolesPages).HasForeignKey(r => r.RoleId).IsRequired();
        builder.HasOne(r => r.Page).WithMany().HasForeignKey(r => r.PageId).IsRequired();
    }
}
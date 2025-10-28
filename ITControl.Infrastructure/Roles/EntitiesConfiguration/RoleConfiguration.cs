using ITControl.Domain.Roles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Roles.EntitiesConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    internal static readonly List<Role> RolesSeed = [
        new Role(new () { Name = "Master", Active = true })
    ];
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).HasMaxLength(64).IsRequired();
        builder.Property(r => r.Active).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(r => r.Name).IsUnique();
        
        builder.HasData(RolesSeed);
    }
}
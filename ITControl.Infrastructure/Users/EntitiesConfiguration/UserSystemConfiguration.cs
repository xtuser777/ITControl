using ITControl.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Users.EntitiesConfiguration;

public class UserSystemConfiguration : IEntityTypeConfiguration<UserSystem>
{
    public void Configure(EntityTypeBuilder<UserSystem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UsersSystems)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne(x => x.System)
            .WithMany()
            .HasForeignKey(x => x.SystemId);
    }
}
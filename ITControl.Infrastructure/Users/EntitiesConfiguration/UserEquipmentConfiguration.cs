using ITControl.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Users.EntitiesConfiguration;

public class UserEquipmentConfiguration : IEntityTypeConfiguration<UserEquipment>
{
    public void Configure(EntityTypeBuilder<UserEquipment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.StartedAt).IsRequired();
        builder.Property(x => x.EndedAt);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UsersEquipments)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne(x => x.Equipment)
            .WithMany()
            .HasForeignKey(x => x.EquipmentId);
    }
}
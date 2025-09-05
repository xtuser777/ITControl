using ITControl.Domain.Notifications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Notifications.EntitiesConfiguration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Title).IsRequired().HasMaxLength(50);
        builder.Property(n => n.Message).IsRequired().HasMaxLength(255);
        builder.Property(n => n.Type).IsRequired();
        builder.Property(n => n.Reference).IsRequired();
        builder.Property(n => n.IsRead).IsRequired().HasDefaultValue(false);
        builder.Property(n => n.UserId).IsRequired();
        builder.Property(n => n.CallId).IsRequired(false);
        builder.Property(n => n.AppointmentId).IsRequired(false);
        builder.Property(n => n.TreatmentId).IsRequired(false);
        builder.HasOne(n => n.User).WithMany().HasForeignKey(n => n.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(n => n.Call).WithMany().HasForeignKey(n => n.CallId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(n => n.Appointment).WithMany().HasForeignKey(n => n.AppointmentId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(n => n.Treatment).WithMany().HasForeignKey(n => n.TreatmentId).OnDelete(DeleteBehavior.NoAction);
        builder.Property(n => n.CreatedAt).IsRequired();
        builder.Property(n => n.UpdatedAt).IsRequired();
    }
}

using ITControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.EntitiesConfiguration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);
        builder
            .Property(a => a.Description)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(a => a.ScheduledAt)
            .IsRequired();
        builder
            .Property(a => a.ScheduledIn)
            .IsRequired();
        builder
            .Property(a => a.Observation)
            .HasMaxLength(255)
            .IsRequired();
        builder
            .Property(a => a.CreatedAt)
            .IsRequired();
        builder
            .Property(a => a.UpdatedAt)
            .IsRequired();
        
        builder
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .IsRequired();
        builder
            .HasOne(a => a.Call)    
            .WithMany()
            .HasForeignKey(a => a.CallId)
            .IsRequired();
        builder
            .HasOne(a => a.Location)
            .WithMany()
            .HasForeignKey(a => a.LocationId)
            .IsRequired();
    }
}
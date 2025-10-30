using ITControl.Domain.Users.Entities;
using ITControl.Infrastructure.Departments.EntitiesConfiguration;
using ITControl.Infrastructure.Divisions.EntitiesConfiguration;
using ITControl.Infrastructure.Positions.EntitiesConfiguration;
using ITControl.Infrastructure.Roles.EntitiesConfiguration;
using ITControl.Infrastructure.Units.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Users.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    [Obsolete("Obsolete")] internal static readonly List<User> UsersSeed = [
        new(new ()
        {
            Name = "Administrador",
            Username = "admin",
            Password = "",
            Document = "02912383005",
            Email = "",
            Enrollment = 9999,
            RoleId = RoleConfiguration.RolesSeed[0].Id,
            PositionId = PositionConfiguration.PositionsSeed[0].Id,
            UnitId = UnitConfiguration.UnitsSeed[0].Id,
            DepartmentId = DepartmentConfiguration
                               .DepartmentsSeed
                               .Find(x => x.Alias == "SEMAD")?.Id
                           ?? Guid.Empty,
            DivisionId = DivisionConfiguration.DivisionsSeed[0].Id,
        })
    ];
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).HasMaxLength(25).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(128).IsRequired();
        builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Document).HasMaxLength(11).IsRequired();
        builder.Property(u => u.Enrollment).IsRequired();
        builder.Property(u => u.Active).IsRequired();
        builder.Property(u => u.PositionId).IsRequired();
        builder.Property(u => u.RoleId).IsRequired();
        builder.Property(u => u.UnitId).IsRequired();
        builder.Property(u => u.DepartmentId).IsRequired();
        builder.Property(u => u.DivisionId).IsRequired();
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Document).IsUnique();

        builder
            .HasOne(u => u.Position)
            .WithMany()
            .HasForeignKey(u => u.PositionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(u => u.Unit)
            .WithMany()
            .HasForeignKey(u => u.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(u => u.Department)
            .WithMany()
            .HasForeignKey (u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(u => u.Division)
            .WithMany()
            .HasForeignKey(u => u.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(UsersSeed);
    }
}

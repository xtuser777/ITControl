using ITControl.Domain.Divisions.Entities;
using ITControl.Infrastructure.Departments.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Divisions.EntitiesConfiguration;

public class DivisionConfiguration : IEntityTypeConfiguration<Division>
{
    internal static readonly List<Division> DivisionsSeed = [
        new(new()
        {
            Name = "Divisão Municipal de Informática",
            DepartmentId = DepartmentConfiguration
                .DepartmentsSeed
                .Find(x => x.Alias == "SEMAD")?.Id
                           ?? Guid.Empty
        })
    ];
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasOne(x => x.Department)
            .WithMany().HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(DivisionsSeed);
    }
}
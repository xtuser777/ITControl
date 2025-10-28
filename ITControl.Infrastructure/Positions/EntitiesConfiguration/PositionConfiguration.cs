using ITControl.Domain.Positions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Positions.EntitiesConfiguration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    internal static readonly List<Position> PositionsSeed = [
        new(new () { Name = "Analista de Sistemas" })
    ];
    
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        
        builder.HasData(PositionsSeed);
    }
}
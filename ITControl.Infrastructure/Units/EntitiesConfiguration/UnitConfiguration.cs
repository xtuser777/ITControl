using ITControl.Domain.Units.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Units.EntitiesConfiguration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    internal static readonly List<Unit> UnitsSeed = [
        new(new()
        {
            Name = "Paço Municipal",
            StreetName = "Rua Marcílio Dias",
            AddressNumber = "719",
            Neighborhood = "Centro",
            PostalCode = "19600000",
            Phone = "1832659200"
        })
    ];
    
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
        builder.Property(x => x.PostalCode).HasMaxLength(8).IsRequired();
        builder.Property(x => x.StreetName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Neighborhood).HasMaxLength(80).IsRequired();
        builder.Property(x => x.AddressNumber).HasMaxLength(5).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        
        builder.HasData(UnitsSeed);
    }
}
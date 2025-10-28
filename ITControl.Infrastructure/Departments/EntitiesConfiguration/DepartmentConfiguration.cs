using ITControl.Domain.Departments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Departments.EntitiesConfiguration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    internal static readonly List<Department> DepartmentsSeed = [
        new(new()
        {
            Alias = "SEMAD",
            Name = "Secretaria Municipal de Administração",
        }),
        new(new()
        {
            Alias = "SEGOV",
            Name = "Secretaria Municipal de Governo",
        }),
        new(new()
        {
            Alias = "SEPLAD",
            Name = "Secretaria Municipal de Planejamento e Desenvolvimento Econômico",
        }),
        new(new()
        {
            Alias = "SEDUC",
            Name = "Secretaria Municipal de Educação",
        }),
        new(new()
        {
            Alias = "SEMSA",
            Name = "Secretaria Municipal de Saúde",
        }),
        new(new()
        {
            Alias = "SEMAG",
            Name = "Secretaria Municipal de Serviços Gerais",
        }),
        new(new()
        {
            Alias = "SECULT",
            Name = "Secretaria Municipal de Cultura e Turismo",
        }),
        new(new()
        {
            Alias = "SEACT",
            Name = "Secretaria Municipal de Assistência Social e Cidadania",
        }),
        new(new()
        {
            Alias = "SEMEL",
            Name = "Secretaria Municipal de Esporte e Lazer",
        }),
        new(new()
        {
            Alias = "SEFAZ",
            Name = "Secretaria Municipal de Finanças",
        }),
        new(new()
        {
            Alias = "SEMAJ",
            Name = "Secretaria Municipal de Assuntos Jurídicos",
        }),
        new(new()
        {
            Alias = "SEMAM",
            Name = "Secretaria Municipal de Agricultura e Meio ambiente",
        }),
        new(new()
        {
            Alias = "SMSP",
            Name = "Secretaria Municipal de Segurança Pública",
        }),
        new(new()
        {
            Alias = "SOURB",
            Name = "Secretaria Municipal de Infraestrutura",
        }),
        new(new()
        {
            Alias = "COINTER",
            Name = "Controladoria Interna",
        }),
        new(new()
        {
            Alias = "GABINETE",
            Name = "Gabinete do Prefeito",
        }),
    ];
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Alias).HasMaxLength(10).IsRequired();
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        builder.Property(d => d.CreatedAt).IsRequired();
        builder.Property(d => d.UpdatedAt).IsRequired();
        builder.HasIndex(d => d.Alias).IsUnique();
        builder.HasIndex(d => d.Name).IsUnique();
        
        builder.HasData(DepartmentsSeed);
    }
}
using ITControl.Domain.Pages.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.Pages.EntitiesConfiguration;

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
    internal static readonly IEnumerable<Page> PagesSeed = new List<Page>([
        new Page(new () { Name = "users" }),
        new Page(new () { Name = "roles" }),
        new Page(new () { Name = "pages" }),
        new Page(new () { Name = "positions" }),
        new Page(new () { Name = "departments" }),
        new Page(new () { Name = "divisions" }),
        new Page(new () { Name = "contracts" }),
        new Page(new () { Name = "equipments" }),
        new Page(new () { Name = "systems" }),
        new Page(new () { Name = "calls" }),
        new Page(new () { Name = "appointments" }),
        new Page(new () { Name = "treatments" }),
        new Page(new () { Name = "notifications" }),
        new Page(new () { Name = "knowledge-bases" }),
        new Page(new () { Name = "profile" }),
        new Page(new () { Name = "supplements" }),
        new Page(new () { Name = "supplements-movements" }),
    ]);
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        
        builder.HasData(PagesSeed);
    }
}
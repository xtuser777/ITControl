using ITControl.Domain.KnowledgeBases.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITControl.Infrastructure.KnowledgeBases.EntitiesConfiguration;

public class KnowledgeBaseConfiguration : IEntityTypeConfiguration<KnowledgeBase>
{
    public void Configure(EntityTypeBuilder<KnowledgeBase> builder)
    {
        builder.ToTable("KnowledgeBases");
        builder.HasKey(kb => kb.Id);
        builder.Property(kb => kb.Title).IsRequired().HasMaxLength(100);
        builder.Property(kb => kb.Content).HasColumnType("text").IsRequired();
        builder.Property(kb => kb.EstimatedTime).IsRequired();
        builder.Property(kb => kb.Reason).IsRequired();
        builder.Property(kb => kb.UserId).IsRequired();
        builder.HasOne(kb => kb.User).WithMany().HasForeignKey(kb => kb.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(kb => kb.CreatedAt).IsRequired();
        builder.Property(kb => kb.UpdatedAt).IsRequired();
    }
}

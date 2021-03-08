using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BugConfiguration : IEntityTypeConfiguration<Bug>
    {
        public void Configure(EntityTypeBuilder<Bug> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("bug_id");

            builder.Property(b => b.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.Reproduce)
                .HasColumnName("reproduce")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.Environment)
                .HasColumnName("environment")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.SuggestionForFix)
                .HasColumnName("suggestion_for_fix")
                .HasMaxLength(500);

            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(b => b.ModifiedAt)
                .HasColumnName("modified_at")
                .HasColumnType("datetime");
        }
    }
}
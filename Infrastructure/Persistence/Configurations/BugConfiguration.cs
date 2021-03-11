using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class BugConfiguration : IEntityTypeConfiguration<Bug>
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

            builder.Property(b => b.StatusId)
                .HasColumnName("status_id");

            builder.HasOne(b => b.Status)
                .WithMany(s => s.Bugs)
                .HasForeignKey(b => b.StatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bug_status");

            builder.Property(b => b.PriorityId)
                .HasColumnName("priority_id");

            builder.HasOne(b => b.Priority)
                .WithMany(p => p.Bugs)
                .HasForeignKey(b => b.PriorityId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bug_priority");

            builder.Property(b => b.ProjectVersionId)
                .HasColumnName("project_version_id");

            builder.HasOne(b => b.ProjectVersion)
                .WithMany(pv => pv.Bugs)
                .HasForeignKey(b => b.ProjectVersionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bug_project_version");

            builder.Property(b => b.CreatedById)
                .HasColumnName("user_id");

            builder.HasOne(b => b.CreatedBy)
                .WithMany(u => u.Bugs)
                .HasForeignKey(b => b.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class DomainTaskConfiguration : IEntityTypeConfiguration<DomainTask>
    {
        public void Configure(EntityTypeBuilder<DomainTask> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("task_id");

            builder.Property(t => t.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.ModifiedAt)
                .HasColumnName("modified_at")
                .HasColumnType("datetime");

            builder.Property(t => t.DueDate)
                .HasColumnName("due_date")
                .HasColumnType("datetime");

            builder.Property(t => t.StatusId)
                .HasColumnName("status_id");

            builder.HasOne(t => t.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_task_status");

            builder.Property(t => t.PriorityId)
                .HasColumnName("priority_id");

            builder.HasOne(t => t.Priority)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_task_priority");

            builder.Property(t => t.ProjectVersionId)
                .HasColumnName("project_version_id");

            builder.HasOne(t => t.ProjectVersion)
                .WithMany(pv => pv.Tasks)
                .HasForeignKey(t => t.ProjectVersionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_task_project_version");

            builder.Property(b => b.CreatedById)
                .HasColumnName("user_id");

            builder.HasOne(t => t.CreatedBy)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_task_user");
        }
    }
}
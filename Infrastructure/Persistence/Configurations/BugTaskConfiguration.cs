using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    internal class BugTaskConfiguration : IEntityTypeConfiguration<BugTask>
    {
        public void Configure(EntityTypeBuilder<BugTask> builder)
        {
            builder.HasKey(bt => new { bt.BugId, bt.TaskId });

            builder.Property(bt => bt.BugId)
                .HasColumnName("bug_id");

            builder.HasOne(bt => bt.Bug)
                .WithMany(b => b.BugTasks)
                .HasForeignKey(bt => bt.BugId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bugtask_bug");

            builder.Property(bt => bt.TaskId)
                .HasColumnName("task_id");

            builder.HasOne(bt => bt.Task)
                .WithMany(t => t.BugTasks)
                .HasForeignKey(bt => bt.TaskId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bugtask_task");
        }
    }
}
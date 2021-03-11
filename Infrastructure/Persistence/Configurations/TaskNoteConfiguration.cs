using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class TaskNoteConfiguration : IEntityTypeConfiguration<TaskNote>
    {
        public void Configure(EntityTypeBuilder<TaskNote> builder)
        {
            builder.Property(bn => bn.TaskId)
                .HasColumnName("task_id");

            builder.HasOne(bn => bn.Task)
                .WithMany(t => t.Notes)
                .HasForeignKey(bn => bn.TaskId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_task_note_task");
        }
    }
}
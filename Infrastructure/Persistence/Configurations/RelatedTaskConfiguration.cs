using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class RelatedTaskConfiguration : IEntityTypeConfiguration<RelatedTask>
    {
        public void Configure(EntityTypeBuilder<RelatedTask> builder)
        {
            builder.HasKey(rt => new { rt.RelatedFromId, rt.RelatedToId });

            builder.Property(rt => rt.RelatedFromId)
                .HasColumnName("related_from_id");

            builder.HasOne(rt => rt.RelatedFrom)
                .WithMany(t => t.RelatedFrom)
                .HasForeignKey(rt => rt.RelatedFromId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_relatedtask_task_from");

            builder.Property(rt => rt.RelatedToId)
                .HasColumnName("related_to_id");

            builder.HasOne(rt => rt.RelatedTo)
                .WithMany(t => t.RelatedTo)
                .HasForeignKey(rt => rt.RelatedToId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_relatedtask_task_to");

            builder.Property(rt => rt.RelationDescription)
                .HasColumnName("description");
        }
    }
}
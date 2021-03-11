using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class RelatedBugConfiguration : IEntityTypeConfiguration<RelatedBug>
    {
        public void Configure(EntityTypeBuilder<RelatedBug> builder)
        {
            builder.HasKey(rb => new { rb.RelatedFromId, rb.RelatedToId });

            builder.Property(rb => rb.RelatedFromId)
                .HasColumnName("related_from_id");

            builder.HasOne(rb => rb.RelatedFrom)
                .WithMany(b => b.RelatedFrom)
                .HasForeignKey(rb => rb.RelatedFromId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_relatedbug_bug_from");

            builder.Property(rb => rb.RelatedToId)
                .HasColumnName("related_to_id");

            builder.HasOne(rb => rb.RelatedTo)
                .WithMany(b => b.RelatedTo)
                .HasForeignKey(rb => rb.RelatedToId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_relatedbug_bug_to");

            builder.Property(rb => rb.RelationDescription)
                .HasColumnName("description");
        }
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class BugNoteConfiguration : IEntityTypeConfiguration<BugNote>
    {
        public void Configure(EntityTypeBuilder<BugNote> builder)
        {
            builder.Property(bn => bn.BugId)
                .HasColumnName("bug_id");

            builder.HasOne(bn => bn.Bug)
                .WithMany(b => b.Notes)
                .HasForeignKey(bn => bn.BugId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_bug_note_bug");
        }
    }
}
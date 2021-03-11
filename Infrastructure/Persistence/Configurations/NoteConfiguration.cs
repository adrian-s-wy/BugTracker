using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                .HasColumnName("note_id");

            builder.Property(n => n.Text)
                .HasColumnName("text")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(n => n.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(n => n.UserId)
                .HasColumnName("user_id");

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_note_user");

            builder.HasDiscriminator<string>("note_type")
                .HasValue<BugNote>("BN")
                .HasValue<TaskNote>("TN");
        }
    }
}
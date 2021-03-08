using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DomainTaskConfiguration : IEntityTypeConfiguration<DomainTask>
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
        }
    }
}
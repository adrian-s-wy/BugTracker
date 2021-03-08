using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectVersionConfiguration : IEntityTypeConfiguration<ProjectVersion>
    {
        public void Configure(EntityTypeBuilder<ProjectVersion> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("version_id");

            builder.Property(v => v.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Number)
                .HasColumnName("number")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Deadline)
                .HasColumnName("deadline")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(v => v.ReleaseDate)
                .HasColumnName("realease_date")
                .HasColumnType("datetime");
        }
    }
}
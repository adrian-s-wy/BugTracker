using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectGroupConfiguration : IEntityTypeConfiguration<ProjectGroup>
    {
        public void Configure(EntityTypeBuilder<ProjectGroup> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("project_group_id");

            builder.Property(g => g.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsRequired();
        }
    }
}
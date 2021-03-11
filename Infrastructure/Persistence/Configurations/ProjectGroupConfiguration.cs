using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class ProjectGroupConfiguration : IEntityTypeConfiguration<ProjectGroup>
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

            builder.Property(g => g.ProjectId)
                .HasColumnName("project_id");

            builder.HasOne(g => g.Project)
                .WithMany(p => p.ProjectGroups)
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_project_group_project");

            builder.Property(g => g.UserGroupId)
                .HasColumnName("user_group_id");

            builder.HasOne(g => g.UserGroup)
                .WithMany(ug => ug.ProjectGroups)
                .HasForeignKey(g => g.UserGroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_project_group_user_group");
        }
    }
}
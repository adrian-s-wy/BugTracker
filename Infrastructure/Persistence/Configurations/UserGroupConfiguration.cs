using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("user_group_id");

            builder.Property(g => g.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
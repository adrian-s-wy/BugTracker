using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasKey(gm => new { gm.UserId, gm.UserGrupId });

            builder.Property(gm => gm.UserId)
                .HasColumnName("user_id");

            builder.HasOne(gm => gm.User)
                .WithMany(u => u.GroupsMember)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_groupmember_user");

            builder.Property(gm => gm.UserGrupId)
                .HasColumnName("user_group_id");

            builder.HasOne(gm => gm.UserGroup)
                .WithMany(g => g.GroupMembers)
                .HasForeignKey(gm => gm.UserGrupId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_groupmember_usergroup");
        }
    }
}
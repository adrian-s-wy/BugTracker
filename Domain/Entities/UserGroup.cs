using Domain.Entities.Relations;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserGroup
    {
        public UserGroup()
        {
            GroupMembers = new List<GroupMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GroupMember> GroupMembers { get; private set; }
    }
}
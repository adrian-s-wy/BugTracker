namespace Domain.Entities.Relations
{
    public class GroupMember
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UserGrupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
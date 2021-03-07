namespace Domain.Entities
{
    public class ProjectGroup
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
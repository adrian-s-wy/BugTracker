using System;

namespace Domain.Entities
{
    public class ProjectVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Project
    {
        public Project()
        {
            ProjectVersions = new List<ProjectVersion>();
            ProjectGroups = new List<ProjectGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProjectVersion> ProjectVersions { get; private set; }

        public ICollection<ProjectGroup> ProjectGroups { get; private set; }
    }
}
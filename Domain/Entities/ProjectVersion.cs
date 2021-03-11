using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProjectVersion
    {
        public ProjectVersion()
        {
            Bugs = new List<Bug>();
            Tasks = new List<DomainTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Bug> Bugs { get; private set; }
        public ICollection<DomainTask> Tasks { get; private set; }
    }
}
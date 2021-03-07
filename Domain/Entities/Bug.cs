using Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Bug
    {
        public Bug()
        {
            RelatedBugs = new List<RelatedBug>();
            BugTasks = new List<BugTask>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reproduce { get; set; }
        public string Environment { get; set; }
        public string SuggestionForFix { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int ProjectVersionId { get; set; }
        public ProjectVersion ProjectVersion { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public ICollection<RelatedBug> RelatedBugs { get; private set; }

        public ICollection<BugTask> BugTasks { get; private set; }
    }
}
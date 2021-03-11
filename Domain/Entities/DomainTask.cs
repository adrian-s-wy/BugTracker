using Domain.Entities.Relations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DomainTask
    {
        public DomainTask()
        {
            RelatedFrom = new List<RelatedTask>();
            RelatedTo = new List<RelatedTask>();
            BugTasks = new List<BugTask>();
            Notes = new List<TaskNote>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int ProjectVersionId { get; set; }
        public ProjectVersion ProjectVersion { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public ICollection<RelatedTask> RelatedFrom { get; private set; }

        public ICollection<RelatedTask> RelatedTo { get; private set; }

        public ICollection<BugTask> BugTasks { get; private set; }

        public ICollection<TaskNote> Notes { get; private set; }
    }
}
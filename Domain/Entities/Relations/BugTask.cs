using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relations
{
    public class BugTask
    {
        public int TaskId { get; set; }
        public DomainTask Task { get; set; }

        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
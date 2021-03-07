using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TaskNote : Note
    {
        public int TaskId { get; set; }
        public DomainTask Task { get; set; }
    }
}
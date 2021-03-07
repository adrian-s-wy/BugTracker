using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relations
{
    public class RelatedTask
    {
        public int FirstTaskId { get; set; }
        public DomainTask FirstTask { get; set; }

        public int SecondTaskId { get; set; }
        public DomainTask SecondTask { get; set; }

        public string RelationDescription { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relations
{
    public class RelatedBug
    {
        public int FirstBugId { get; set; }
        public Bug FirstBug { get; set; }

        public int SecondBugId { get; set; }
        public Bug SecondBug { get; set; }

        public string RelationDescription { get; set; }
    }
}
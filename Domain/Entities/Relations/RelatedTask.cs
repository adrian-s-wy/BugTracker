using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relations
{
    public class RelatedTask
    {
        public int RelatedFromId { get; set; }
        public DomainTask RelatedFrom { get; set; }

        public int RelatedToId { get; set; }
        public DomainTask RelatedTo { get; set; }

        public string RelationDescription { get; set; }
    }
}
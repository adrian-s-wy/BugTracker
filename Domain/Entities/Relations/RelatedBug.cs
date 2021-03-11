using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relations
{
    public class RelatedBug
    {
        public int RelatedFromId { get; set; }
        public Bug RelatedFrom { get; set; }

        public int RelatedToId { get; set; }
        public Bug RelatedTo { get; set; }

        public string RelationDescription { get; set; }
    }
}
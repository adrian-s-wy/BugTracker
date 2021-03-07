using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BugNote : Note
    {
        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
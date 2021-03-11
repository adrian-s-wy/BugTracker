using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Status
    {
        public Status()
        {
            Bugs = new List<Bug>();
            Tasks = new List<DomainTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bug> Bugs { get; private set; }

        public ICollection<DomainTask> Tasks { get; private set; }

        public static int Open
        {
            get { return 1; }
        }

        public static int Closed
        {
            get { return 2; }
        }
    }
}
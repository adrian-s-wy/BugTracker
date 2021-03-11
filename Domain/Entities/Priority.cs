using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Priority
    {
        public Priority()
        {
            Bugs = new List<Bug>();
            Tasks = new List<DomainTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bug> Bugs { get; private set; }
        public ICollection<DomainTask> Tasks { get; private set; }

        public static int Critical { get { return 1; } }
        public static int Urgent { get { return 2; } }
        public static int Medium { get { return 3; } }
        public static int Low { get { return 4; } }
        public static int VeryLow { get { return 5; } }
    }
}
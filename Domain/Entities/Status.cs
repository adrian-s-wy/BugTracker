using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
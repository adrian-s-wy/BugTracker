using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
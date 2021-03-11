using Domain.Entities.Relations;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            GroupsMember = new List<GroupMember>();
            Notes = new List<Note>();
            Bugs = new List<Bug>();
            Tasks = new List<DomainTask>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public ICollection<GroupMember> GroupsMember { get; private set; }
        public ICollection<Note> Notes { get; private set; }
        public ICollection<Bug> Bugs { get; private set; }
        public ICollection<DomainTask> Tasks { get; private set; }
    }
}
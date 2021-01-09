using Domain.Common;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<HouseholdTask> Tasks { get; set; }
        public BigInteger MyProperty { get; set; }

        public HouseholdGroup(string name)
        {
            Name = name;
            Members = new List<User>();
            Tasks = new List<HouseholdTask>();
        }

        public void AddMember(User member)
        {
            Members.Add(member);
        }

        public void RemoveMember(User member)
        {
            Members.Remove(member);
        }

        public void AddTask(HouseholdTask task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(HouseholdTask task)
        {
            Tasks.Remove(task);
        }
    }
}

using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Members { get;  } = new List<User>();
        public ICollection<HouseholdTask> Tasks { get; } = new List<HouseholdTask>();

        public HouseholdGroup(string name)
        {
            Name = name;
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

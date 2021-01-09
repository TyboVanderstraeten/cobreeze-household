using Domain.Common;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<HouseholdMember> Members { get; set; }
        public ICollection<HouseholdTask> Tasks { get; set; }
        public BigInteger MyProperty { get; set; }

        public HouseholdGroup(string name)
        {
            Name = name;
            Members = new List<HouseholdMember>();
            Tasks = new List<HouseholdTask>();
        }

        public void AddMember(HouseholdMember member)
        {
            Members.Add(member);
        }

        public void RemoveMember(HouseholdMember member)
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

using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<HouseholdMember> Members { get; set; }
        public ICollection<HouseholdTask> Tasks { get; set; }

        public HouseholdGroup(string name)
        {
            Name = name;
            Members = new List<HouseholdMember>();
            Tasks = new List<HouseholdTask>();
        }
    }
}

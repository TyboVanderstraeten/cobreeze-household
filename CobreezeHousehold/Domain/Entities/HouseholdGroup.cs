using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Members { get;  } = new List<User>();
        public ICollection<HouseholdTask> Tasks { get; } = new List<HouseholdTask>();
        public ICollection<ShoppingList> ShoppingsLists { get; } = new List<ShoppingList>();

        public HouseholdGroup(string name)
        {
            Name = name;
        }
    }
}

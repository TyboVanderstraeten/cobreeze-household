using Domain.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<User> Members { get;  } = new List<User>();
        [JsonIgnore]
        public ICollection<HouseholdTask> Tasks { get; } = new List<HouseholdTask>();
        [JsonIgnore]
        public ICollection<ShoppingList> ShoppingsLists { get; } = new List<ShoppingList>();

        public HouseholdGroup(string name)
        {
            Name = name;
        }
    }
}

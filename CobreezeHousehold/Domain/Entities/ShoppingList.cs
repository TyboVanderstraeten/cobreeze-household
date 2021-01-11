using Domain.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShoppingList : EditableBaseEntity
    {
        public int HouseholdGroupId { get; set; }
        [JsonIgnore]
        public HouseholdGroup Household { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<ShoppingListItem> Items { get; } = new List<ShoppingListItem>();

        public ShoppingList(string name)
        {
            Name = name;
        }
    }
}

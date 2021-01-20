using Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShoppingList : EditableBaseEntity
    {
        public int HouseholdGroupId { get; set; }
        [JsonIgnore]
        public virtual HouseholdGroup Household { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<ShoppingListItem> Items { get; } = new List<ShoppingListItem>();

        public ShoppingList(string name)
        {
            Name = name;
        }

        public ShoppingListItem GetShoppingListItemById(int id)
        {
            return Items.SingleOrDefault(sli => sli.Id == id);
        }

        public void AddShoppingListItem(ShoppingListItem item)
        {
            Items.Add(item);
        }

        public void RemoveShoppingListItem(ShoppingListItem item)
        {
            Items.Remove(item);
        }
    }
}

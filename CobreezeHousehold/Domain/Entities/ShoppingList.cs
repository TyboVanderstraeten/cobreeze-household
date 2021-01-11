using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ShoppingList : EditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<ShoppingListItem> Items { get; } = new List<ShoppingListItem>();

        public ShoppingList(string name)
        {
            Name = name;
        }
    }
}

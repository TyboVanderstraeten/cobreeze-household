using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShoppingListItem : EditableBaseEntity
    {
        public int ShoppingListId { get; set; }
        [JsonIgnore]
        public virtual ShoppingList ShoppingList { get; set; }
        public string Description { get; set; }
        public int RecipientId { get; set; }
        [JsonIgnore]
        public virtual User Recipient { get; set; }

        public ShoppingListItem(string description)
        {
            Description = description;
        }
    }
}

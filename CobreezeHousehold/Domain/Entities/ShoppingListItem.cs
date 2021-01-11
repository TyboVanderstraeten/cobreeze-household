using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShoppingListItem : EditableBaseEntity
    {
        public int ShoppingListId { get; set; }
        [JsonIgnore]
        public ShoppingList ShoppingList { get; set; }
        public string Description { get; set; }
        public int RecipientId { get; set; }
        [JsonIgnore]
        public User Recipient { get; set; }
    }
}

using Domain.Common;

namespace Domain.Entities
{
    public class ShoppingListItem : EditableBaseEntity
    {
        public string Description { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}

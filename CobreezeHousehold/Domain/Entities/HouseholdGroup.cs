using Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class HouseholdGroup : EditableBaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Members { get; } = new List<User>();
        [JsonIgnore]
        public virtual ICollection<HouseholdTask> Tasks { get; } = new List<HouseholdTask>();
        [JsonIgnore]
        public virtual ICollection<ShoppingList> ShoppingLists { get; } = new List<ShoppingList>();

        public HouseholdGroup(string name)
        {
            Name = name;
        }

        public User GetMemberById(int id)
        {
            return Members.SingleOrDefault(m => m.Id == id);
        }

        public void AddMember(User user)
        {
            Members.Add(user);
        }

        public void RemoveMember(User user)
        {
            Members.Remove(user);
        }

        public HouseholdTask GetTaskById(int id)
        {
            return Tasks.SingleOrDefault(t => t.Id == id);
        }

        public void AddTask(HouseholdTask task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(HouseholdTask task)
        {
            Tasks.Remove(task);
        }

        public ShoppingList GetShoppingListById(int id)
        {
            return ShoppingLists.SingleOrDefault(sl => sl.Id == id);
        }

        public void AddShoppingList(ShoppingList shoppingList)
        {
            ShoppingLists.Add(shoppingList);
        }

        public void RemoveShoppingList(ShoppingList shoppingList)
        {
            ShoppingLists.Remove(shoppingList);
        }
    }
}

using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHouseholdGroupRepositoryAsync : IGenericRepositoryAsync<HouseholdGroup>
    {
        Task<User> AddUserByHouseholdIdAsync(int id, User user, CancellationToken cancellationToken = default);
        Task<User> DeleteUserByHouseholdIdAsync(int id, User user, CancellationToken cancellationToken = default);

        Task<HouseholdTask> AddTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default);
        Task<HouseholdTask> UpdateTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default);
        Task<HouseholdTask> DeleteTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default);

        Task<ShoppingList> AddShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default);
        Task<ShoppingList> UpdateShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default);
        Task<ShoppingList> DeleteShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<User>> GetAllUsersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

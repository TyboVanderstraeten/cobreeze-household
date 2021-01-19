using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHouseholdGroupRepositoryAsync : IGenericRepositoryAsync<HouseholdGroup>
    {
        Task<IReadOnlyList<User>> GetAllMembersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<User> GetMemberByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<HouseholdTask> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ShoppingList> GetShoppingListByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

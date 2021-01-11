using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHouseholdGroupRepositoryAsync : IGenericRepositoryAsync<HouseholdGroup>
    {
        Task<IReadOnlyList<User>> GetAllUsersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

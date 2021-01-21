using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHouseholdGroupRepositoryAsync : IGenericRepositoryAsync<HouseholdGroup>
    {
        Task<IReadOnlyCollection<User>> GetAllMembersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

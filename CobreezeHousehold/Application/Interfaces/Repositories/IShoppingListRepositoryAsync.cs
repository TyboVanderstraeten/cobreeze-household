using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IShoppingListRepositoryAsync
    {
        Task<IReadOnlyList<ShoppingListItem>> GetAllShoppingListItemsByShoppingListIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ShoppingListItem> GetShoppingListItemByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IShoppingListRepositoryAsync : IGenericRepositoryAsync<ShoppingList>
    {
        Task<IReadOnlyCollection<ShoppingListItem>> GetAllShoppingListItemsByShoppingListIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

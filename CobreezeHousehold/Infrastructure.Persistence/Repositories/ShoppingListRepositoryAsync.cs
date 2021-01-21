using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ShoppingListRepositoryAsync : GenericRepositoryAsync<ShoppingList>, IShoppingListRepositoryAsync
    {
        private readonly DbSet<ShoppingList> _shoppingLists;

        public ShoppingListRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _shoppingLists = dbContext.Set<ShoppingList>();
        }

        public async Task<IReadOnlyCollection<ShoppingListItem>> GetAllShoppingListItemsByShoppingListIdAsync(int id, CancellationToken cancellationToken = default)
        {
            ShoppingList shoppingList = await _shoppingLists.SingleOrDefaultAsync(sl => sl.Id == id);

            return (IReadOnlyCollection<ShoppingListItem>)shoppingList?.Items;
        }
    }
}

using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class HouseholdGroupRepositoryAsync : GenericRepositoryAsync<HouseholdGroup>, IHouseholdGroupRepositoryAsync
    {
        private readonly DbSet<HouseholdGroup> _householdGroups;

        public HouseholdGroupRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _householdGroups = dbContext.Set<HouseholdGroup>();
        }

        public async Task<IReadOnlyCollection<User>> GetAllMembersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyCollection<User>)household?.Members;
        }

        public async Task<IReadOnlyCollection<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyCollection<HouseholdTask>)household?.Tasks;
        }

        public async Task<IReadOnlyCollection<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyCollection<ShoppingList>)household?.ShoppingLists;
        }
    }
}

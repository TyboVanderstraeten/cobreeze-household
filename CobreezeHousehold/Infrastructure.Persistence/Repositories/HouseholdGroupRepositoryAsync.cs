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

        public async Task<IReadOnlyList<User>> GetAllUsersByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                                                            

                                    .Include(hg => hg.Members)
                                    .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyList<User>)household?.Members;
        }

        public async Task<IReadOnlyList<HouseholdTask>> GetAllTasksByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                        

                                                    .Include(hg => hg.Tasks)
                                                .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyList<HouseholdTask>)household?.Tasks;
        }

        public async Task<IReadOnlyList<ShoppingList>> GetAllShoppingListsByHouseholdIdAsync(int id, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                
                                                    .Include(hg => hg.ShoppingsLists)
                                                .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyList<ShoppingList>)household?.ShoppingsLists;
        }
    }
}

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

        public async Task<User> AddMemberByHouseholdIdAsync(int id, User user, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                   .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.Members.Add(user);

            return user;
        }

        public async Task<User> DeleteMemberByHouseholdIdAsync(int id, User user, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                   .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.Members.Remove(user);

            return user;
        }

        public async Task<HouseholdTask> AddTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                    .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.Tasks.Add(task);

            return task;
        }

        public async Task<HouseholdTask> UpdateTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HouseholdTask> DeleteTaskByHouseholdIdAsync(int id, HouseholdTask task, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                    .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.Tasks.Remove(task);

            return task;
        }

        public async Task<ShoppingList> AddShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                    .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.ShoppingsLists.Add(shoppingList);

            return shoppingList;
        }

        public async Task<ShoppingList> UpdateShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ShoppingList> DeleteShoppingListByHouseholdIdAsync(int id, ShoppingList shoppingList, CancellationToken cancellationToken = default)
        {
            HouseholdGroup household = await _householdGroups
                                    .SingleOrDefaultAsync(hg => hg.Id == id, cancellationToken);

            household.ShoppingsLists.Remove(shoppingList);

            return shoppingList;
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

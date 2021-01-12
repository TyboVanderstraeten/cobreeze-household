using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _users;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
        }

        public async Task<IReadOnlyList<HouseholdGroup>> GetAllHouseholdsByUserIdAsync(int id, CancellationToken cancellationToken = default)
        {
            User user = await _users                                        
                        .Include(u => u.Households)
                        .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            return (IReadOnlyList<HouseholdGroup>)user?.Households;
        }
    }
}

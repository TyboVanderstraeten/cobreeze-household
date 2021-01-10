using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<HouseholdGroup> Households { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

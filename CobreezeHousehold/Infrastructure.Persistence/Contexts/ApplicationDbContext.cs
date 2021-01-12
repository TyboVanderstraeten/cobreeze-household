using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    /*
     * TODO: users and households should not have plural table name
     */
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<HouseholdGroup> HouseholdGroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService,
            IAuthenticatedUserService authenticatedUserService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _dateTimeService = dateTimeService;
            _authenticatedUserService = authenticatedUserService;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<EditableBaseEntity> entry in ChangeTracker.Entries<EditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUserService.UserId;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

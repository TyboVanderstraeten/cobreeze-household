using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<HouseholdGroup> HouseholdGroups { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService,
            IAuthenticatedUserService authenticatedUserService) : base(options)
        {
            _dateTimeService = dateTimeService;
            _authenticatedUserService = authenticatedUserService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();

            /*
             * TODO: remove
             */
            optionsBuilder.LogTo(log => Debug.WriteLine(log));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * TODO: custom config classes
             */
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<HouseholdGroup>().ToTable("HouseholdGroup");
            modelBuilder.Entity<ShoppingList>().ToTable("ShoppingList");
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

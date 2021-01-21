using Application.Interfaces;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext
                        .Set<T>()
                        .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _dbContext
                        .Set<T>()
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext
                        .Set<T>()
                        .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext
                 .Set<T>()
                 .AddAsync(entity, cancellationToken);

            await _dbContext
                 .SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext
                .Set<T>()
                .Update(entity);

            await _dbContext
                 .SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext
                .Set<T>()
                .Remove(entity);

            await _dbContext
                .SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().CountAsync(cancellationToken);
        }
    }
}

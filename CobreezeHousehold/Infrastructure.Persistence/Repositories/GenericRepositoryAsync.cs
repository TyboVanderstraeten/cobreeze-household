using Application.Interfaces;
using Application.Wrappers;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Cache _cache;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _cache = Cache.GetInstance();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<T> cachedData = _cache.Get<List<T>>($"{typeof(T)}_GetAll");

            if (cachedData == default(List<T>))
            {
                await Task.Delay(1500);

                List<T> data = await _dbContext
                            .Set<T>()
                            .ToListAsync(cancellationToken);

                _cache.Set($"{typeof(T)}_GetAll", data);

                Task.Run(() =>
                {
                    Debug.WriteLine("\n\n--------------- RETRIEVED FROM DATABASE ---------------\n\n");
                    Debug.WriteLine(_cache);
                });
                return data;
            }

            Task.Run(() =>
            {
                Debug.WriteLine("\n\n--------------- RETRIEVED FROM CACHE ---------------\n\n");
                Debug.WriteLine(_cache);
            });

            return cachedData;
        }

        public async Task<PagedResponse<IReadOnlyCollection<T>>> GetPagedResponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int totalRecords = await _dbContext.Set<T>().CountAsync(cancellationToken);

            IReadOnlyList<T> data = await _dbContext
                        .Set<T>()
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);

            return new PagedResponse<IReadOnlyCollection<T>>(data, pageNumber, pageSize, totalRecords);
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
    }
}

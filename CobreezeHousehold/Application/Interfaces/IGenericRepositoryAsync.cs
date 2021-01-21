using Application.Wrappers;
using Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PagedResponse<IReadOnlyCollection<T>>> GetPagedResponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}

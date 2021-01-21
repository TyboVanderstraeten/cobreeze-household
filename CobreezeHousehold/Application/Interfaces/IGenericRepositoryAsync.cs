using Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}

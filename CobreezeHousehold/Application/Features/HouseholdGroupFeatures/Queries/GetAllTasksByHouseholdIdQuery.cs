using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetAllTasksByHouseholdIdQuery : IRequest<PagedResponse<IEnumerable<HouseholdTask>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllTasksByHouseholdIdQueryHandler : IRequestHandler<GetAllTasksByHouseholdIdQuery, PagedResponse<IEnumerable<HouseholdTask>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllTasksByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<PagedResponse<IEnumerable<HouseholdTask>>> Handle(GetAllTasksByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<HouseholdTask> householdTasks = await _householdGroupRepositoryAsync.GetAllTasksByHouseholdIdAsync(query.Id, cancellationToken);

                if (householdTasks == null)
                {
                    throw new ApiException("Tasks Not Found.");
                }

                return new PagedResponse<IEnumerable<HouseholdTask>>(householdTasks, query.PageNumber, query.PageSize);
            }
        }
    }
}
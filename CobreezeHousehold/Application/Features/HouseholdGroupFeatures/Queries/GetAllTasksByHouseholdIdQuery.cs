using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Queries
{
    public class GetAllTasksByHouseholdIdQuery : IRequest<Response<IReadOnlyCollection<HouseholdTask>>>
    {
        public int Id { get; set; }

        public class GetAllTasksByHouseholdIdQueryHandler : IRequestHandler<GetAllTasksByHouseholdIdQuery, Response<IReadOnlyCollection<HouseholdTask>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllTasksByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<IReadOnlyCollection<HouseholdTask>>> Handle(GetAllTasksByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<HouseholdTask> tasks = await _householdGroupRepositoryAsync.GetAllTasksByHouseholdIdAsync(query.Id, cancellationToken);

                if (tasks == null)
                {
                    throw new ApiException("Tasks Not Found.");
                }

                return new Response<IReadOnlyCollection<HouseholdTask>>(tasks);
            }
        }
    }
}
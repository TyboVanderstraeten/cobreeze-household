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
    public class GetAllHouseholdsQuery : IRequest<PagedResponse<IEnumerable<HouseholdGroup>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllHouseholdsQueryHandler : IRequestHandler<GetAllHouseholdsQuery, PagedResponse<IEnumerable<HouseholdGroup>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllHouseholdsQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<PagedResponse<IEnumerable<HouseholdGroup>>> Handle(GetAllHouseholdsQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyList<HouseholdGroup> households = await _householdGroupRepositoryAsync.GetPagedResponseAsync(query.PageNumber, query.PageSize, cancellationToken);

                if (households == null)
                {
                    throw new ApiException("Households Not Found.");
                }

                return new PagedResponse<IEnumerable<HouseholdGroup>>(households, query.PageNumber, query.PageSize, households.Count);
            }
        }
    }
}

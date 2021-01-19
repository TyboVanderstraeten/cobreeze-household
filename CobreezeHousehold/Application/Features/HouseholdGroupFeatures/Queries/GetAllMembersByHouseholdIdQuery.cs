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
    public class GetAllMembersByHouseholdIdQuery : IRequest<PagedResponse<IEnumerable<User>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllMembersByHouseholdIdQueryHandler : IRequestHandler<GetAllMembersByHouseholdIdQuery, PagedResponse<IEnumerable<User>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllMembersByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<PagedResponse<IEnumerable<User>>> Handle(GetAllMembersByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyList<User> users = await _householdGroupRepositoryAsync.GetAllMembersByHouseholdIdAsync(query.Id, cancellationToken);

                if (users == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return new PagedResponse<IEnumerable<User>>(users, query.PageNumber, query.PageSize, users.Count);
            }
        }
    }
}

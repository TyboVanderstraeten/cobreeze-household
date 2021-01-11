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
    public class GetAllUsersByHouseholdIdQuery : IRequest<PagedResponse<IEnumerable<User>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllUsersByHouseholdIdQueryHandler : IRequestHandler<GetAllUsersByHouseholdIdQuery, PagedResponse<IEnumerable<User>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllUsersByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<PagedResponse<IEnumerable<User>>> Handle(GetAllUsersByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<User> users = await _householdGroupRepositoryAsync.GetAllUsersByHouseholdIdAsync(query.Id, cancellationToken);

                if (users == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return new PagedResponse<IEnumerable<User>>(users, query.PageNumber, query.PageSize);
            }
        }
    }
}

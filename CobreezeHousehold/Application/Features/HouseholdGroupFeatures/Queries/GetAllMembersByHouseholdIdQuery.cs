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
    public class GetAllMembersByHouseholdIdQuery : IRequest<Response<IReadOnlyCollection<User>>>
    {
        public int Id { get; set; }

        public class GetAllMembersByHouseholdIdQueryHandler : IRequestHandler<GetAllMembersByHouseholdIdQuery, Response<IReadOnlyCollection<User>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllMembersByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<IReadOnlyCollection<User>>> Handle(GetAllMembersByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<User> users = await _householdGroupRepositoryAsync.GetAllMembersByHouseholdIdAsync(query.Id, cancellationToken);

                if (users == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return new Response<IReadOnlyCollection<User>>(users);
            }
        }
    }
}

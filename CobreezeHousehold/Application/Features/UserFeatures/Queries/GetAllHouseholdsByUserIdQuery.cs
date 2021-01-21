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
    public class GetAllHouseholdsByUserIdQuery : IRequest<Response<IReadOnlyCollection<HouseholdGroup>>>
    {
        public int Id { get; set; }

        public class GetAllHouseholdsByUserIdQueryHandler : IRequestHandler<GetAllHouseholdsByUserIdQuery, Response<IReadOnlyCollection<HouseholdGroup>>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public GetAllHouseholdsByUserIdQueryHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<IReadOnlyCollection<HouseholdGroup>>> Handle(GetAllHouseholdsByUserIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<HouseholdGroup> households = await _userRepository.GetAllHouseholdsByUserIdAsync(query.Id, cancellationToken);

                if (households == null)
                {
                    throw new ApiException("Households Not Found.");
                }

                return new Response<IReadOnlyCollection<HouseholdGroup>>(households);
            }
        }
    }
}

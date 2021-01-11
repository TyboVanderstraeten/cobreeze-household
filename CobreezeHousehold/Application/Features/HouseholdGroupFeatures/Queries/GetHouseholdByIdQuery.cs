using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdFeatures.Queries
{
    public class GetHouseholdByIdQuery : IRequest<Response<HouseholdGroup>>
    {
        public int Id { get; set; }

        public class GetHouseholdByIdQueryHandler : IRequestHandler<GetHouseholdByIdQuery, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdRepository;

            public GetHouseholdByIdQueryHandler(IHouseholdGroupRepositoryAsync householdRepository)
            {
                _householdRepository = householdRepository;
            }

            public async Task<Response<HouseholdGroup>> Handle(GetHouseholdByIdQuery query, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdRepository.GetByIdAsync(query.Id, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

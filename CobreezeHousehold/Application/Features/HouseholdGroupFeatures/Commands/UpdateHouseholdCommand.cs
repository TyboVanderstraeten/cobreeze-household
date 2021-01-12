using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class UpdateHouseholdCommand : IRequest<Response<HouseholdGroup>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateHouseholdCommandHandler : IRequestHandler<UpdateHouseholdCommand, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public UpdateHouseholdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<HouseholdGroup>> Handle(UpdateHouseholdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.Id, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                household.Name = command.Name;

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

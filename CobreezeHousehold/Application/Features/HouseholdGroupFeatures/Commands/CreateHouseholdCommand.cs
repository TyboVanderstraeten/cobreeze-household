using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class CreateHouseholdCommand : IRequest<Response<HouseholdGroup>>
    {
        public int CreatorId { get; set; }

        public string Name { get; set; }

        public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;
            private readonly IUserRepositoryAsync _userRepositoryAsync;

            public CreateHouseholdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync, IUserRepositoryAsync userRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
                _userRepositoryAsync = userRepositoryAsync;
            }

            public async Task<Response<HouseholdGroup>> Handle(CreateHouseholdCommand command, CancellationToken cancellationToken)
            {
                User creator = await _userRepositoryAsync.GetByIdAsync(command.CreatorId, cancellationToken);

                if (creator == null)
                {
                    throw new ApiException("User Not Found.");
                }

                HouseholdGroup household = new HouseholdGroup(command.Name);
                household.Members.Add(creator);

                await _householdGroupRepositoryAsync.AddAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

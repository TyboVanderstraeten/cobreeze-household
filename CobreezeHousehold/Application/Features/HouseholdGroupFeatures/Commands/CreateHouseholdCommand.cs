using Application.Exceptions;
using Application.Interfaces;
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
        public string Name { get; set; }

        public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;
            private readonly IUserRepositoryAsync _userRepositoryAsync;
            private readonly IAuthenticatedUserService _authenticatedUser;

            public CreateHouseholdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync, IUserRepositoryAsync userRepositoryAsync, IAuthenticatedUserService authenticatedUser)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
                _userRepositoryAsync = userRepositoryAsync;
                _authenticatedUser = authenticatedUser;
            }

            public async Task<Response<HouseholdGroup>> Handle(CreateHouseholdCommand command, CancellationToken cancellationToken)
            {
                int creatorId = _authenticatedUser.UserId;

                User creator = await _userRepositoryAsync.GetByIdAsync(creatorId, cancellationToken);

                if (creator == null)
                {
                    throw new ApiException("User Not Found.");
                }

                HouseholdGroup household = new HouseholdGroup(command.Name);

                await _householdGroupRepositoryAsync.AddAsync(household, cancellationToken);

                household.Members.Add(creator);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    /*
     * TODO: link creator to household? Is this the good way? Research
     */
    public class CreateHouseholdCommand : IRequest<Response<HouseholdGroup>>
    {
        public string Name { get; set; }
        public int CreatorId { get; set; }

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
                HouseholdGroup household = new HouseholdGroup(command.Name);

                await _householdGroupRepositoryAsync.AddAsync(household, cancellationToken);

                User creator = await _userRepositoryAsync.GetByIdAsync(command.CreatorId, cancellationToken);

                household.Members.Add(creator);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

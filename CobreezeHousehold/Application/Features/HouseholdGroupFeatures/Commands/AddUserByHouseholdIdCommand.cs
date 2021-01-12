using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class AddUserByHouseholdIdCommand : IRequest<Response<User>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public class AddUserByHouseholdIdCommandHandler : IRequestHandler<AddUserByHouseholdIdCommand, Response<User>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;
            private readonly IUserRepositoryAsync _userRepositoryAsync;

            public AddUserByHouseholdIdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync, IUserRepositoryAsync userRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
                _userRepositoryAsync = userRepositoryAsync;
            }

            public async Task<Response<User>> Handle(AddUserByHouseholdIdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.Id, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                User user = await _userRepositoryAsync.GetByIdAsync(command.UserId, cancellationToken);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }

                household.Members.Add(user);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<User>(user);
            }
        }
    }
}

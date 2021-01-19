using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class DeleteMemberByIdCommand : IRequest<Response<User>>
    {
        public int HouseholdId { get; set; }

        public int UserId { get; set; }

        public class DeleteMemberByIdCommandHandler : IRequestHandler<DeleteMemberByIdCommand, Response<User>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;
            private readonly IUserRepositoryAsync _userRepositoryAsync;

            public DeleteMemberByIdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync, IUserRepositoryAsync userRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
                _userRepositoryAsync = userRepositoryAsync;
            }

            public async Task<Response<User>> Handle(DeleteMemberByIdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.HouseholdId, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                User user = await _userRepositoryAsync.GetByIdAsync(command.UserId, cancellationToken);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }

                household.RemoveMember(user);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<User>(user);
            }
        }
    }
}

using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class DeleteHouseholdByIdCommand : IRequest<Response<HouseholdGroup>>
    {
        public int Id { get; set; }

        public class DeleteHouseholdByIdCommandHandler : IRequestHandler<DeleteHouseholdByIdCommand, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public DeleteHouseholdByIdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<HouseholdGroup>> Handle(DeleteHouseholdByIdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.Id, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                await _householdGroupRepositoryAsync.DeleteAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}

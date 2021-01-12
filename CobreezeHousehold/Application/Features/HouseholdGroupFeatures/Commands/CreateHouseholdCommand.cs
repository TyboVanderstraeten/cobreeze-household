﻿using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    /*
     * TODO: link creator to household?
     */
    public class CreateHouseholdCommand : IRequest<Response<HouseholdGroup>>
    {
        public string Name { get; set; }

        public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, Response<HouseholdGroup>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public CreateHouseholdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<HouseholdGroup>> Handle(CreateHouseholdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = new HouseholdGroup(command.Name);

                await _householdGroupRepositoryAsync.AddAsync(household, cancellationToken);

                return new Response<HouseholdGroup>(household);
            }
        }
    }
}
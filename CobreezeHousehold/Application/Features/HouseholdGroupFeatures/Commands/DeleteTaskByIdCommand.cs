﻿using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class DeleteTaskByIdCommand : IRequest<Response<HouseholdTask>>
    {
        public int HouseholdId { get; set; }

        public int TaskId { get; set; }

        public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, Response<HouseholdTask>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public DeleteTaskByIdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<HouseholdTask>> Handle(DeleteTaskByIdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.HouseholdId, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                HouseholdTask task = household.GetTaskById(command.TaskId);

                if (task == null)
                {
                    throw new ApiException("Task Not Found.");
                }

                household.RemoveTask(task);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<HouseholdTask>(task);
            }
        }
    }
}

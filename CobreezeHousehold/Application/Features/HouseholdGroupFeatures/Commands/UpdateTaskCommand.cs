using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class UpdateTaskCommand : IRequest<Response<HouseholdTask>>
    {
        public int HouseholdId { get; set; }

        public int TaskId { get; set; }
        public TaskType TaskType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ExecutorId { get; set; }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<HouseholdTask>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public UpdateTaskCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<HouseholdTask>> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
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

                task.TaskType = command.TaskType;
                task.Name = command.Name;
                task.Description = command.Description;
                task.StartTime = command.StartTime;
                task.EndTime = command.EndTime;
                task.ExecutorId = command.ExecutorId;

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<HouseholdTask>(task);
            }
        }
    }
}

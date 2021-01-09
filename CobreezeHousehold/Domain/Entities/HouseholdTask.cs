using Domain.Common;
using Domain.Common.Enums;
using System;

namespace Domain.Entities
{
    public abstract class HouseholdTask : EditableBaseEntity
    {
        public int HouseholdGroupId { get; set; }
        public HouseholdGroup Household { get; set; }
        public TaskType TaskType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ExecutorId { get; set; }
        public HouseholdMember Executor { get; set; }

        public HouseholdTask(TaskType taskType, string name)
        {
            TaskType = taskType;
            Name = name;
        }
    }
}

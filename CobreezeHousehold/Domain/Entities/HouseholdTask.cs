using Domain.Common;
using Domain.Common.Enums;
using System;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class HouseholdTask : EditableBaseEntity
    {
        public int HouseholdGroupId { get; set; }
        [JsonIgnore]
        public HouseholdGroup Household { get; set; }
        public TaskType TaskType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ExecutorId { get; set; }
        [JsonIgnore]
        public User Executor { get; set; }

        public HouseholdTask(TaskType taskType, string name)
        {
            TaskType = taskType;
            Name = name;
        }
    }
}

using System.Text.Json.Serialization;
using static TaskManagement.Data.Entities.PriorityLevel;
using static TaskManagement.Data.Entities.StatusLevel;

namespace TaskManagement.Data.Entities
{
    public class Tasks
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

    }

    public class PriorityLevel
    {
        public enum Priority        {

            Low,
            Medium,
            High
        }
    }

    public class StatusLevel
    {
        
        public enum Status
        {
            New,
            InProgress,
            Finished
        }
    }


}

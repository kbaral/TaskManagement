using TaskManagement.Data.Entities;

namespace TaskManagement.Models
{
    public class TasksResponse
    {
        public TasksResponse(string Message, Tasks tasks)
        {
            this.ResponseMessage = Message;
            this.Tasks = tasks;
        }
        public Tasks Tasks { get; set; }
        public string ResponseMessage { get; set; }

    }
}

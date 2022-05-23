
using TaskManagement.Models;

namespace TaskManagement.Services.Tasks
{
    public interface ITasksService
    {
        bool Delete(int id);
        IEnumerable<Data.Entities.Tasks> FindAll();
        Data.Entities.Tasks? FindOne(int id);
        TasksResponse Insert(Data.Entities.Tasks task);
        bool Update(Data.Entities.Tasks task);
    }
}

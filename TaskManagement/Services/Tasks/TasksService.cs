using TaskManagement.Data;
using TaskManagement.Data.Entities;
using TaskManagement.Models;

namespace TaskManagement.Services.Tasks
{
    public class TasksService : ITasksService
    {
        private readonly TaskContext _context;
        public TasksService(TaskContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var entity = FindOne(id);
            if (entity != null)
            {
                _context.Tasks.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<Data.Entities.Tasks> FindAll()
        {    
            return _context.Tasks.ToList().OrderByDescending(c => c.DueDate);
        }

        public Data.Entities.Tasks? FindOne(int id)
        {
            var tasks = _context.Tasks.ToList();
            return tasks.Find(x => x.Id == id);
        }

        public TasksResponse Insert(Data.Entities.Tasks task)
        {
            try
            {
                if (task.DueDate < DateTime.Now)
                {
                    return new TasksResponse("Error: Due date cannot be in the past.", task);
                }
                else
                {
                    var results = _context.Tasks
                                .Where(x => (x.Priority == PriorityLevel.Priority.High && (x.Status == StatusLevel.Status.New || x.Status == StatusLevel.Status.InProgress)))
                                .GroupBy(x => x.DueDate)
                                .Select(x => new
                                {
                                    DueDate = x.Key,
                                    Count = x.Count()
                                })
                                .ToList();
                    var closeCounts = results.Where(x => x.Count == 100);
                    foreach (var item in closeCounts)
                    {
                        if (item.DueDate == task.DueDate)
                        {
                            return new TasksResponse("Error: We cannot have more than 100 high priority tasks which are pending.", task);
                        }
                    }

                    _context.Tasks.Add(task);

                    return _context.SaveChanges() > 0 ? new TasksResponse("Success", task) : new TasksResponse("Error", task);

                }
            }
            catch (Exception ex)
            {
                return new TasksResponse($"Error: {ex.Message}", task);
            }
        }

        public bool Update(Data.Entities.Tasks task)
        {
            _context.Tasks.Update(task);
            return _context.SaveChanges() > 0 ;
        }
    }
}

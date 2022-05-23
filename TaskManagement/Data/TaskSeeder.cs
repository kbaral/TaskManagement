using System.Text.Json;
using TaskManagement.Data.Entities;

namespace TaskManagement.Data
{
    public class TaskSeeder
    {
        private readonly TaskContext _context;
        private readonly IWebHostEnvironment _env;
        public TaskSeeder(TaskContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            if (!_context.Tasks.Any())
            {
                //var filePath = Path.Combine(_env.ContentRootPath, "Data/seed.json");
                //var json = File.ReadAllText(filePath);
                //var tasks = JsonSerializer.Deserialize<IEnumerable<Tasks>>(json);

                //_context.Tasks.AddRange(tasks);

                //_context.SaveChanges();
            }
        }

    }
}

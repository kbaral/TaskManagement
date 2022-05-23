using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using TaskManagement.Data;
using TaskManagement.Data.Entities;
using TaskManagement.Services.Tasks;
using Xunit;

namespace TaskManagementTests
{
    public class TaskManagementTests
    {
        private readonly TaskContext _context;
        public TaskManagementTests()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()
                );
            _context = new TaskContext(options.Options);
        }
        [Fact]        
        public void Add_Returns_Tasks()
        {
            //Execute method of SUT (TaskService)
            var tasks = GetTasks();
            var service = new TasksService(_context);
            var task = service.Insert(tasks);

            //Assert  
            Assert.NotNull(task);
        }
        [Fact]
        public void Add_Returns_Tasks_Fails_DueDate()
        {
            //Execute method of SUT (TasksService)
            var tasks = GetTasks();
            tasks.DueDate = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            var service = new TasksService(_context);
            var task = service.Insert(tasks);

            //Assert  
            Assert.Equal("Error: Due date cannot be in the past.", task.ResponseMessage);
        }

        [Fact]
        public void Update_Returns_Tasks()
        {
            //Execute method of SUT (TasksService)
            var tasks = GetTasks();
            var service = new TasksService(_context);
            service.Insert(tasks);
            tasks.Name = "Test updated name";
            var task = service.Update(tasks);

            //Assert  
            Assert.NotNull(task);
        }

        [Fact]
        public void GetAll_Returns_Tasks()
        {
            //Execute method of SUT (Task Service)
            var tasks = GetTasks();
            var service = new TasksService(_context);
            service.Insert(tasks);            
            var task = service.FindAll();

            //Assert  
            Assert.NotNull(task);
        }

        [Fact]
        public void Get_Returns_Tasks()
        {
            //Execute method of SUT (Task SErvice)
            var tasks = GetTasks();
            var service = new TasksService(_context);
            var task = service.Insert(tasks);
            var foundTask = service.FindOne(task.Tasks.Id);

            //Assert  
            Assert.NotNull(foundTask);
        }

        [Fact]
        public void Delete_Tasks()
        {
            //Execute method of SUT (Task SErvice)
            var tasks = GetTasks();
            var service = new TasksService(_context);
            var task = service.Insert(tasks);
            var foundTask = service.Delete(task.Tasks.Id);

            //Assert  
            Assert.True(foundTask);
        }

        private Tasks GetTasks()
        {
            return new Tasks
            {
                Id = 1,
                Description = "Test Tasks",
                Name = "Test Name",
                DueDate = DateTime.Now.AddDays(30),
                StartDate = DateTime.Now.AddDays(3),
                EndDate = DateTime.Now.AddDays(30),
                Priority = PriorityLevel.Priority.High,
                Status = StatusLevel.Status.New

            };
        }
    }
}
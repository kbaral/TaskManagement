using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data.Entities;
using TaskManagement.Models;
using TaskManagement.Services.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return _tasksService.FindAll();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public ActionResult<Tasks> Get(int id)
        {
            var result = _tasksService.FindOne(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        // POST api/<TasksController>
        [HttpPost]
        public ActionResult<TasksResponse> Post([FromBody] Tasks task)
        {
            var response = _tasksService.Insert(task);
            if (response != default)
                return Ok(response);
            else
                return BadRequest();
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public ActionResult<TasksResponse> Put(int id, [FromBody] Tasks task)
        {
            var result = _tasksService.Update(task);
            return result ? Ok(new TasksResponse("Success: Task updated", task)) : NotFound();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _tasksService.Delete(id);
            return result ? true : NotFound();
        }
    }
}

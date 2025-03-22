using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/task
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/task/{id}
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound(new { message = "Task not found" });

            return Ok(task);
        }

        // POST: api/task
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = _taskService.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/task/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTask = _taskService.UpdateTask(id, taskDto);
            if (updatedTask == null)
                return NotFound(new { message = "Task not found" });

            return Ok(updatedTask);
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var deletedTask = _taskService.DeleteTask(id);
            if (deletedTask == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            return Ok(deletedTask);
        }
    }
}

using System;
using System.Collections.Generic;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        // Create a new task
        TaskDto CreateTask(TaskDto taskDto);

        // Get all tasks
        IEnumerable<TaskDto> GetAllTasks();

        // Get tasks assigned to a specific user
        IEnumerable<TaskDto> GetTasksByUserId(int userId);

        // Update task details (e.g., status, priority)
        TaskDto UpdateTask(int taskId, TaskDto updatedTaskDto);

        // Delete a task
        TaskDto DeleteTask(int taskId);

        TaskDto GetTaskById(int id);
    }
}

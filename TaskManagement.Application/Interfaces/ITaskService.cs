using System;
using System.Collections.Generic;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        
        TaskDto CreateTask(TaskDto taskDto);

        
        IEnumerable<TaskDto> GetAllTasks();

        
        IEnumerable<TaskDto> GetTasksByUserId(int userId);

        
        TaskDto UpdateTask(int taskId, TaskDto updatedTaskDto);

        
        TaskDto DeleteTask(int taskId);

        TaskDto GetTaskById(int id);
    }
}

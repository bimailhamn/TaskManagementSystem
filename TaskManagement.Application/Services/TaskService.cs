using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using System.Threading.Tasks;
using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;
namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskDto CreateTask(TaskDto taskDto)
        {
            if (taskDto.DueDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                AssignedUserId = taskDto.AssignedUserId
            };

            _taskRepository.Add(task);

          
            var createdTaskDto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                AssignedUserId = task.AssignedUserId
            };

            return createdTaskDto; 
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            var tasks = _taskRepository.GetAll();
            return tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                AssignedUserId = task.AssignedUserId
            });
        }

        public TaskDto GetTaskById(int taskId)
        {
            var task = _taskRepository.GetById(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                AssignedUserId = task.AssignedUserId
            };
        }

        public TaskDto UpdateTask(int taskId, TaskDto updatedTaskDto)
        {
            var task = _taskRepository.GetById(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            if (updatedTaskDto.DueDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            
            task.Title = updatedTaskDto.Title;
            task.Description = updatedTaskDto.Description;
            task.DueDate = updatedTaskDto.DueDate;
            task.Priority = updatedTaskDto.Priority;
            task.Status = updatedTaskDto.Status;
            task.AssignedUserId = updatedTaskDto.AssignedUserId;

            _taskRepository.Update(task);

            
            var updatedTaskDtoResponse = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                AssignedUserId = task.AssignedUserId
            };

            return updatedTaskDtoResponse; 
        }

        public TaskDto DeleteTask(int taskId)
        {
            var task = _taskRepository.GetById(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            
            var taskDto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                AssignedUserId = task.AssignedUserId
            };

            
            _taskRepository.Delete(task.Id);

            return taskDto; 
        }

        public IEnumerable<TaskDto> GetTasksByUserId(int userId)
        {
            var tasks = _taskRepository.GetTasksByUserId(userId);
            return tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                AssignedUserId = task.AssignedUserId
            });
        }
    }
}

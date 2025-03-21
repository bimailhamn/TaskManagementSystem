using TaskManagement.Domain.Entities;
using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; } // Unique identifier for the task.
        public required string Title { get; set; } // Title of the task.
        public required string Description { get; set; } // Detailed description of the task.
        public DateTime DueDate { get; set; } // Due date for the task completion.
        public TaskPriority Priority { get; set; } // Priority of the task (e.g., High, Medium, Low).
        public DomainTaskStatus Status { get; set; } // Current status of the task (e.g., Pending, In Progress, Completed).
        public int AssignedUserId { get; set; } // ID of the user assigned to this task, if any.
        public string AssignedUserName { get; set; } // Name of the user assigned to this task, for display purposes.
    }
}

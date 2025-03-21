using System;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; } // Unique identifier for the task.
        public required string Title { get; set; } // Title of the task.
        public required string Description { get; set; } // Detailed description of the task.
        public DateTime DueDate { get; set; } // Deadline for the task.
        public TaskPriority Priority { get; set; } // Priority level of the task.
        public TaskStatus Status { get; set; } // Current status of the task.
        public int AssignedUserId { get; set; } // ID of the user the task is assigned to.
        public bool IsCompleted { get; set; }
        public User AssignedUser { get; set; }

        // Method to validate task properties
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentException("Task title cannot be empty.");

            if (DueDate < DateTime.Now)
                throw new ArgumentException("Due date cannot be in the past.");
        }
    }

    // Enum for task priority levels
    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    // Enum for task status
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }
}

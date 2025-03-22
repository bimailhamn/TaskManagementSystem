using System;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; } 
        public required string Title { get; set; } 
        public required string Description { get; set; } 
        public DateTime DueDate { get; set; } 
        public TaskPriority Priority { get; set; } 
        public TaskStatus Status { get; set; } 
        public int AssignedUserId { get; set; } 
        public bool IsCompleted { get; set; }
        public User AssignedUser { get; set; }

       
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentException("Task title cannot be empty.");

            if (DueDate < DateTime.Now)
                throw new ArgumentException("Due date cannot be in the past.");
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
            Status = TaskStatus.Completed;
        }

        public void UpdateDetails(string newTitle, string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Task title cannot be empty.");

            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Task description cannot be empty.");

            Title = newTitle;
            Description = newDescription;
        }
    }

    
    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

   
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }
}

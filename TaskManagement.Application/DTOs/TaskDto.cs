using TaskManagement.Domain.Entities;
using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; } 
        public required string Title { get; set; } 
        public required string Description { get; set; } 
        public DateTime DueDate { get; set; } 
        public TaskPriority Priority { get; set; } 
        public DomainTaskStatus Status { get; set; } 
        public int AssignedUserId { get; set; } 
        public string? AssignedUserName { get; set; }

        public bool IsCompleted { get; set; } 
    }
}

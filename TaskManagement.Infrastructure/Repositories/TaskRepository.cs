using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of ITaskRepository for managing tasks in the database.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public TaskRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public TaskItem Add(TaskItem task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            
            _context.Tasks.Add(task);

            
            _context.SaveChanges();

            return task;
        }

        /// <inheritdoc />
        public void Delete(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {taskId} not found.");
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public TaskItem? GetById(int taskId)
        {
            return _context.Tasks.Find(taskId);
        }

        /// <inheritdoc />
        public IEnumerable<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        /// <inheritdoc />
        public void Update(TaskItem task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            
            var existingTask = _context.Tasks.Find(task.Id);
            if (existingTask == null)
                throw new KeyNotFoundException($"Task with ID {task.Id} not found.");

            
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted = task.IsCompleted;

           
            _context.Tasks.Update(existingTask);

            
            _context.SaveChanges();
        }

        public IEnumerable<TaskItem> GetTasksByUserId(int userId)
        {
            
            return _context.Tasks.Where(task => task.AssignedUserId == userId).ToList();
        }

    }
}

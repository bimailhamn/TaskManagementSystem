using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    /// <summary>
    /// Defines the repository contract for managing tasks.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        IEnumerable<TaskItem> GetAll();

        /// <summary>
        /// Retrieves a task by its unique identifier.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task.</param>
        /// <returns>The task with the specified ID, or null if not found.</returns>
        TaskItem? GetById(int taskId);

        /// <summary>
        /// Retrieves all tasks assigned to a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A list of tasks assigned to the user.</returns>
        IEnumerable<TaskItem> GetTasksByUserId(int userId);

        /// <summary>
        /// Adds a new task to the repository.
        /// </summary>
        /// <param name="task">The task to add.</param>
        TaskItem Add(TaskItem task);

        /// <summary>
        /// Updates an existing task in the repository.
        /// </summary>
        /// <param name="task">The task with updated details.</param>
        void Update(TaskItem task);

        /// <summary>
        /// Deletes a task from the repository.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task to delete.</param>
        void Delete(int taskId);

        /// <summary>
        /// Checks whether a task exists in the repository.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task.</param>
        /// <returns>True if the task exists, otherwise false.</returns>
       
    }
}

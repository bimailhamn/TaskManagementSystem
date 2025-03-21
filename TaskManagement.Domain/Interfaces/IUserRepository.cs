using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    /// <summary>
    /// Defines the repository contract for managing users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        User? GetById(int userId);

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user with the specified email, or null if not found.</returns>
        User? GetByEmail(string email);

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        User? Add(User user);

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="user">The user with updated details.</param>
        void Update(User user);

        /// <summary>
        /// Deletes a user from the repository.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to delete.</param>
        void Delete(int userId);

        /// <summary>
        /// Checks whether a user exists in the repository.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>True if the user exists, otherwise false.</returns>
    }
}

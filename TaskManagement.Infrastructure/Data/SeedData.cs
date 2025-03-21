using System;
using System.Linq;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    /// <summary>
    /// Provides methods to seed initial data into the database.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Seeds initial data into the database if it's empty.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public static void Initialize(AppDbContext context)
        {
            // Check if the Users table is empty
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        PasswordHash = "hashed_password_1" // Ensure PasswordHash exists in User entity
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        PasswordHash = "hashed_password_2" // Ensure PasswordHash exists in User entity
                    }
                );
            }

            // Check if the Tasks table is empty
            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new TaskItem
                    {
                        Id = 1,
                        Title = "Complete documentation",
                        Description = "Finalize the project documentation for TaskManagementSystem.",
                        AssignedUserId = context.Users.First().Id,
                        DueDate = DateTime.Now.AddDays(7),
                        IsCompleted = false // Ensure IsCompleted exists in TaskItem entity
                    },
                    new TaskItem
                    {
                        Id = 2,
                        Title = "Fix login bug",
                        Description = "Resolve the issue where users cannot log in with their credentials.",
                        AssignedUserId = context.Users.Last().Id,
                        DueDate = DateTime.Now.AddDays(3),
                        IsCompleted = false // Ensure IsCompleted exists in TaskItem entity
                    }
                );
            }

            // Save changes to the database
            context.SaveChanges();
        }
    }
}

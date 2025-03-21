namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } // Unique identifier for the user.
        public required string Name { get; set; } // Name of the user.
        public required string Email { get; set; } // Email address of the user.
        public string PasswordHash { get; set; }

        // Collection of tasks assigned to the user
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

        // Method to validate user properties
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("User name cannot be empty.");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new ArgumentException("Invalid email address.");
        }
    }
}

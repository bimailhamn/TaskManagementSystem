namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public required string Name { get; set; } 
        public required string Email { get; set; } 
        public string PasswordHash { get; set; }

        public bool IsActive { get; set; }

        
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

        
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("User name cannot be empty.");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new ArgumentException("Invalid email address.");
        }

        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
                throw new ArgumentException("Invalid email address.");
            
            Email = newEmail;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}

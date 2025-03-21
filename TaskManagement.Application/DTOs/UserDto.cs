namespace TaskManagement.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; } // Unique identifier for the user.
        public required string Name { get; set; } // Full name of the user.
        public required string Email { get; set; } // Email address of the user.
        public string? Role { get; set; } // Role of the user (e.g., Admin, User).
    }
}

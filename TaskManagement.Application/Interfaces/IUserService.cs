using System.Collections.Generic;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces
{
    public interface IUserService
    {
        // Create a new user
        UserDto CreateUser(UserDto userDto);

        // Get all users
        IEnumerable<UserDto> GetAllUsers();

        // Get a user by ID
        UserDto GetUserById(int userId);

        // Update user details
        UserDto UpdateUser(int userId, UserDto updatedUserDto);

        // Delete a user
        UserDto DeleteUser(int userId);
    }
}

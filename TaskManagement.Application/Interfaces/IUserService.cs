using System.Collections.Generic;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces
{
    public interface IUserService
    {
        
        UserDto CreateUser(UserDto userDto);

        
        IEnumerable<UserDto> GetAllUsers();

        
        UserDto GetUserById(int userId);

        
        UserDto UpdateUser(int userId, UserDto updatedUserDto);

        
        UserDto DeleteUser(int userId);
    }
}

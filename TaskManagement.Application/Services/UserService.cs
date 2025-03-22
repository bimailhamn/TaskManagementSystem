using System.Collections.Generic;
using System.Linq;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email
            };

            _userRepository.Add(user);

            
            var createdUserDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return createdUserDto;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
        }

        public UserDto GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserDto UpdateUser(int userId, UserDto updatedUserDto)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            
            user.Name = updatedUserDto.Name;
            user.Email = updatedUserDto.Email;

           
            _userRepository.Update(user);

            
            var updatedUserDtoResult = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return updatedUserDtoResult;
        }

        public UserDto DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            
            var deletedUserDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            
            _userRepository.Delete(user.Id);

            
            return deletedUserDto;
        }

    }
}

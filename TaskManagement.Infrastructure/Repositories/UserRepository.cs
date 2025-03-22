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
    /// Implementation of IUserRepository for managing users in the database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public User Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user); 
            _context.SaveChanges();
            return user;
        }

        /// <inheritdoc />
        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public User? GetById(int userId)
        {
            
            return _context.Users.Find(userId);
        }

        /// <inheritdoc />

        public IEnumerable<User> GetAll()
        {
            
            return _context.Users.ToList();
        }


        /// <inheritdoc />
        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");

           
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            
            _context.Users.Update(existingUser);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public User? GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        
    }
}

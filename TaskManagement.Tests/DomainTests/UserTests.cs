using System;
using TaskManagement.Domain.Entities;
using Xunit;

namespace TaskManagement.Tests.DomainTests
{
   public class UserTests
   {
       [Fact]
        public void Can_Create_User_With_Valid_Data()
        {
            var username = "testuser";
            var email = "testuser@example.com";
            var user = new User
            {
                Name = username,
                Email = email
            };

            // Assert
            Assert.NotNull(user);
            Assert.Equal(username, user.Name);
            Assert.Equal(email, user.Email);
        }

       [Fact]
        public void Cannot_Create_User_With_Empty_Username()
        {
            var username = string.Empty;
            var email = "testuser@example.com";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var user = new User
                {
                    Name = username,
                    Email = email
                };
                user.Validate();
            });

            Assert.Equal("User name cannot be empty.", exception.Message);
        }
       

       [Fact]
        public void Cannot_Create_User_With_Invalid_Email()
        {
            var username = "testuser";
            var email = "invalid-email";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var user = new User
                {
                    Name = username,
                    Email = email
                };
                user.Validate();
            });

            Assert.Equal("Invalid email address.", exception.Message);
        }

       [Fact]
        public void Can_Update_User_Email()
        {
            var user = new User
            {
                Name = "testuser",
                Email = "testuser@example.com"
            };
            var newEmail = "updateduser@example.com";
            user.UpdateEmail(newEmail);
            Assert.Equal(newEmail, user.Email);
        }

       [Fact]
        public void Can_Activate_User()
        {
            var user = new User
            {
                Name = "testuser",
                Email = "testuser@example.com"
            };
            user.Activate();
            Assert.True(user.IsActive);
        }

       [Fact]
        public void Can_Deactivate_User()
        {
            var user = new User
            {
                Name = "testuser",
                Email = "testuser@example.com"
            };
            user.Activate();

            // Act
            user.Deactivate();

            Assert.False(user.IsActive);
        }
   }
}

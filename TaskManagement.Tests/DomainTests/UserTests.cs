//using System;
//using TaskManagement.Domain.Entities;
//using Xunit;

//namespace TaskManagement.Tests.DomainTests
//{
//    public class UserTests
//    {
//        [Fact]
//        public void Can_Create_User_With_Valid_Data()
//        {
//            // Arrange
//            var username = "testuser";
//            var email = "testuser@example.com";

//            // Act
//            var user = new User(username, email);

//            // Assert
//            Assert.NotNull(user);
//            Assert.Equal(username, user.Username);
//            Assert.Equal(email, user.Email);
//        }

//        [Fact]
//        public void Cannot_Create_User_With_Empty_Username()
//        {
//            // Arrange
//            var username = string.Empty;
//            var email = "testuser@example.com";

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => new User(username, email));
//        }

//        [Fact]
//        public void Cannot_Create_User_With_Invalid_Email()
//        {
//            // Arrange
//            var username = "testuser";
//            var email = "invalid-email";

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => new User(username, email));
//        }

//        [Fact]
//        public void Can_Update_User_Email()
//        {
//            // Arrange
//            var user = new User("testuser", "testuser@example.com");
//            var newEmail = "updateduser@example.com";

//            // Act
//            user.UpdateEmail(newEmail);

//            // Assert
//            Assert.Equal(newEmail, user.Email);
//        }

//        [Fact]
//        public void Cannot_Update_User_With_Invalid_Email()
//        {
//            // Arrange
//            var user = new User("testuser", "testuser@example.com");
//            var invalidEmail = "invalid-email";

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => user.UpdateEmail(invalidEmail));
//        }

//        [Fact]
//        public void Can_Activate_User()
//        {
//            // Arrange
//            var user = new User("testuser", "testuser@example.com");

//            // Act
//            user.Activate();

//            // Assert
//            Assert.True(user.IsActive);
//        }

//        [Fact]
//        public void Can_Deactivate_User()
//        {
//            // Arrange
//            var user = new User("testuser", "testuser@example.com");
//            user.Activate(); // Activate first

//            // Act
//            user.Deactivate();

//            // Assert
//            Assert.False(user.IsActive);
//        }
//    }
//}

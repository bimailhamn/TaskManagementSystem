//using System;
//using TaskManagement.Domain.Entities;
//using Xunit;

//namespace TaskManagement.Tests.DomainTests
//{
//    public class TaskItemTests
//    {
//        [Fact]
//        public void Can_Create_TaskItem_With_Valid_Data()
//        {
//            // Arrange
//            var title = "Test Task";
//            var description = "This is a test task";
//            var dueDate = DateTime.Now.AddDays(7);
//            var createdBy = "testuser";

//            // Act
//            var taskItem = new TaskItem(title, description, dueDate, createdBy);

//            // Assert
//            Assert.NotNull(taskItem);
//            Assert.Equal(title, taskItem.Title);
//            Assert.Equal(description, taskItem.Description);
//            Assert.Equal(dueDate, taskItem.DueDate);
//            Assert.Equal(createdBy, taskItem.CreatedBy);
//            Assert.False(taskItem.IsCompleted);
//        }

//        [Fact]
//        public void Cannot_Create_TaskItem_With_Empty_Title()
//        {
//            // Arrange
//            var title = string.Empty;
//            var description = "This is a test task";
//            var dueDate = DateTime.Now.AddDays(7);
//            var createdBy = "testuser";

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => new TaskItem(title, description, dueDate, createdBy));
//        }

//        [Fact]
//        public void Cannot_Create_TaskItem_With_Past_DueDate()
//        {
//            // Arrange
//            var title = "Test Task";
//            var description = "This is a test task";
//            var dueDate = DateTime.Now.AddDays(-1); // Past date
//            var createdBy = "testuser";

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => new TaskItem(title, description, dueDate, createdBy));
//        }

//        [Fact]
//        public void Can_Mark_TaskItem_As_Completed()
//        {
//            // Arrange
//            var taskItem = new TaskItem("Test Task", "This is a test task", DateTime.Now.AddDays(7), "testuser");

//            // Act
//            taskItem.MarkAsCompleted();

//            // Assert
//            Assert.True(taskItem.IsCompleted);
//        }

//        [Fact]
//        public void Can_Update_TaskItem_Title_And_Description()
//        {
//            // Arrange
//            var taskItem = new TaskItem("Test Task", "This is a test task", DateTime.Now.AddDays(7), "testuser");
//            var newTitle = "Updated Task";
//            var newDescription = "Updated description";

//            // Act
//            taskItem.UpdateDetails(newTitle, newDescription);

//            // Assert
//            Assert.Equal(newTitle, taskItem.Title);
//            Assert.Equal(newDescription, taskItem.Description);
//        }
//    }
//}

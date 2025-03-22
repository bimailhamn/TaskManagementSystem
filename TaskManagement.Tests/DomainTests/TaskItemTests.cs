using System;
using TaskManagement.Domain.Entities;
using Xunit;
using DomainTaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Tests.DomainTests
{
   public class TaskItemTests
   {
       [Fact]
        public void Can_Create_TaskItem_With_Valid_Data()
        {
            var title = "Test Task";
            var description = "This is a test task";
            var dueDate = DateTime.Now.AddDays(7);
            var taskItem = new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = TaskPriority.Medium,
                Status = DomainTaskStatus.InProgress,
                IsCompleted = false
            };

            Assert.NotNull(taskItem);
            Assert.Equal(title, taskItem.Title);
            Assert.Equal(description, taskItem.Description);
            Assert.Equal(dueDate, taskItem.DueDate);
            Assert.False(taskItem.IsCompleted);
        }


       [Fact]
        public void Cannot_Create_TaskItem_With_Empty_Title()
        {
            var title = string.Empty;
            var taskItem = new TaskItem
            {
                Title = title,
                Description = "This is a test task",
                DueDate = DateTime.Now.AddDays(7),
                Priority = TaskPriority.Medium,
                Status = DomainTaskStatus.InProgress,
                IsCompleted = false
            };
            Assert.Throws<ArgumentException>(() => taskItem.Validate());
        }

       [Fact]
        public void Cannot_Create_TaskItem_With_Past_DueDate()
        {
            var taskItem = new TaskItem
            {
                Title = "Test Task",
                Description = "This is a test task",
                DueDate = DateTime.Now.AddDays(-1)
            };
            Assert.Throws<ArgumentException>(() => taskItem.Validate());
        }

       [Fact]
        public void Can_Mark_TaskItem_As_Completed()
        {
            var taskItem = new TaskItem
            {
                Title = "Test Task",
                Description = "This is a test task",
                DueDate = DateTime.Now.AddDays(7),
                AssignedUser = new User { Name = "testuser" , Email = "testuser@gmail.com"},
                IsCompleted = false
            };

            taskItem.MarkAsCompleted();

            Assert.True(taskItem.IsCompleted);
        }

       [Fact]
        public void Can_Update_TaskItem_Title_And_Description()
        {
            var taskItem = new TaskItem
            {
                Title = "Test Task",
                Description = "This is a test task",
                DueDate = DateTime.Now.AddDays(7)
            };
            var newTitle = "Updated Task";
            var newDescription = "Updated description";

            taskItem.UpdateDetails(newTitle, newDescription);

            Assert.Equal(newTitle, taskItem.Title);
            Assert.Equal(newDescription, taskItem.Description);
        }
   }
}

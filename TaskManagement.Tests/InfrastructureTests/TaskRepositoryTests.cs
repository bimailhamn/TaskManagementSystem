//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using TaskManagement.Domain.Entities;
//using TaskManagement.Domain.Interfaces;
//using TaskManagement.Infrastructure.Data;
//using TaskManagement.Infrastructure.Repositories;
//using Xunit;

//namespace TaskManagement.Tests.InfrastructureTests
//{
//    public class TaskRepositoryTests
//    {
//        private readonly AppDbContext _dbContext;
//        private readonly ITaskRepository _taskRepository;

//        public TaskRepositoryTests()
//        {
//            // In-memory database setup
//            var options = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                .Options;

//            _dbContext = new AppDbContext(options);

//            // Seed data for tests
//            _dbContext.Tasks.AddRange(new List<TaskItem>
//            {
//                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
//                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true },
//            });

//            _dbContext.SaveChanges();

//            // Initialize repository
//            _taskRepository = new TaskRepository(_dbContext);
//        }

//        [Fact]
//        public void GetAll_Returns_All_Tasks()
//        {
//            // Act
//            var result = _taskRepository.GetAll();

//            // Assert
//            Assert.Equal(2, result.Count());
//            Assert.Contains(result, t => t.Title == "Task 1");
//            Assert.Contains(result, t => t.Title == "Task 2");
//        }

//        [Fact]
//        public void GetById_Returns_Task_If_Exists()
//        {
//            // Act
//            var result = _taskRepository.GetById(1);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal("Task 1", result.Title);
//        }

//        [Fact]
//        public void GetById_Returns_Null_If_Not_Exists()
//        {
//            // Act
//            var result = _taskRepository.GetById(999);

//            // Assert
//            Assert.Null(result);
//        }

//        [Fact]
//        public void Add_Saves_New_Task()
//        {
//            // Arrange
//            var newTask = new TaskItem { Title = "Task 3", Description = "Description 3", IsCompleted = false };

//            // Act
//            _taskRepository.Add(newTask);
//            _dbContext.SaveChanges();

//            // Assert
//            var result = _dbContext.Tasks.FirstOrDefault(t => t.Title == "Task 3");
//            Assert.NotNull(result);
//            Assert.Equal("Task 3", result.Title);
//        }

//        [Fact]
//        public void Update_Modifies_Existing_Task()
//        {
//            // Arrange
//            var task = _dbContext.Tasks.First();
//            task.Title = "Updated Task";

//            // Act
//            _taskRepository.Update(task);
//            _dbContext.SaveChanges();

//            // Assert
//            var result = _dbContext.Tasks.First(t => t.Id == task.Id);
//            Assert.Equal("Updated Task", result.Title);
//        }

//        [Fact]
//        public void Delete_Removes_Task()
//        {
//            // Arrange
//            var task = _dbContext.Tasks.First();

//            // Act
//            _taskRepository.Delete(task.Id);
//            _dbContext.SaveChanges();

//            // Assert
//            var result = _dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id);
//            Assert.Null(result);
//        }
//    }
//}

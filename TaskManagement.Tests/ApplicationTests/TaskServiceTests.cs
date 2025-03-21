//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Moq;
//using TaskManagement.Application.Interfaces;
//using TaskManagement.Application.Services;
//using TaskManagement.Application.DTOs;
//using TaskManagement.Domain.Entities;
//using TaskManagement.Domain.Interfaces;
//using Xunit;

//namespace TaskManagement.Tests.ApplicationTests
//{
//    public class TaskServiceTests
//    {
//        private readonly Mock<ITaskRepository> _mockTaskRepository;
//        private readonly ITaskService _taskService;

//        public TaskServiceTests()
//        {
//            // Mock the TaskRepository
//            _mockTaskRepository = new Mock<ITaskRepository>();

//            // Create an instance of TaskService with the mocked repository
//            _taskService = new TaskService(_mockTaskRepository.Object);
//        }

//        [Fact]
//        public void GetAllTasks_Returns_All_Tasks()
//        {
//            // Arrange
//            var mockTasks = new List<TaskItem>
//            {
//                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
//                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true },
//            };

//            _mockTaskRepository
//                .Setup(repo => repo.GetAll())
//                .Returns(mockTasks);

//            // Act
//            var result = _taskService.GetAllTasks();

//            // Assert
//            Assert.Equal(2, result.Count());
//            Assert.Equal("Task 1", result.First().Title);
//            _mockTaskRepository.Verify(repo => repo.GetAll(), Times.Once);
//        }

//        [Fact]
//        public void GetTaskById_Returns_Task_If_Found()
//        {
//            // Arrange
//            var mockTask = new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false };

//            _mockTaskRepository
//                .Setup(repo => repo.GetById(1))
//                .Returns(mockTask);

//            // Act
//            var result = _taskService.GetTaskById(1);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal("Task 1", result.Title);
//            _mockTaskRepository.Verify(repo => repo.GetById(1), Times.Once);
//        }

//        [Fact]
//        public void GetTaskById_Throws_Exception_If_Not_Found()
//        {
//            // Arrange
//            _mockTaskRepository
//                .Setup(repo => repo.GetById(It.IsAny<int>()))
//                .Returns((TaskItem)null);

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => _taskService.GetTaskById(999));
//            _mockTaskRepository.Verify(repo => repo.GetById(999), Times.Once);
//        }

//        [Fact]
//        public void AddTask_Calls_Repository_Add_Method()
//        {
//            // Arrange
//            var taskDto = new TaskDto { Title = "New Task", Description = "New Description", IsCompleted = false };

//            // Act
//            _taskService.AddTask(taskDto);

//            // Assert
//            _mockTaskRepository.Verify(repo => repo.Add(It.IsAny<TaskItem>()), Times.Once);
//        }

//        [Fact]
//        public void UpdateTask_Calls_Repository_Update_Method()
//        {
//            // Arrange
//            var taskDto = new TaskDto { Id = 1, Title = "Updated Task", Description = "Updated Description", IsCompleted = true };

//            _mockTaskRepository
//                .Setup(repo => repo.GetById(1))
//                .Returns(new TaskItem { Id = 1, Title = "Old Task", Description = "Old Description", IsCompleted = false });

//            // Act
//            _taskService.UpdateTask(taskDto);

//            // Assert
//            _mockTaskRepository.Verify(repo => repo.Update(It.IsAny<TaskItem>()), Times.Once);
//        }

//        [Fact]
//        public void DeleteTask_Calls_Repository_Delete_Method()
//        {
//            // Arrange
//            var taskId = 1;

//            _mockTaskRepository
//                .Setup(repo => repo.GetById(taskId))
//                .Returns(new TaskItem { Id = taskId });

//            // Act
//            _taskService.DeleteTask(taskId);

//            // Assert
//            _mockTaskRepository.Verify(repo => repo.Delete(taskId), Times.Once);
//        }
//    }
//}

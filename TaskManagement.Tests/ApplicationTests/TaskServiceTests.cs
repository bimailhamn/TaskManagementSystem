using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using Xunit;

namespace TaskManagement.Tests.ApplicationTests
{
   public class TaskServiceTests
   {
       private readonly Mock<ITaskRepository> _mockTaskRepository;
       private readonly ITaskService _taskService;

       public TaskServiceTests()
       {
           
           _mockTaskRepository = new Mock<ITaskRepository>();

           
           _taskService = new TaskService(_mockTaskRepository.Object);
       }

       [Fact]
       public void GetAllTasks_Returns_All_Tasks()
       {
           
           var mockTasks = new List<TaskItem>
           {
               new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
               new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true },
           };

           _mockTaskRepository
               .Setup(repo => repo.GetAll())
               .Returns(mockTasks);

           
           var result = _taskService.GetAllTasks();

           Assert.Equal(2, result.Count());
           Assert.Equal("Task 1", result.First().Title);
           _mockTaskRepository.Verify(repo => repo.GetAll(), Times.Once);
       }

       [Fact]
       public void GetTaskById_Returns_Task_If_Found()
       {
           
           var mockTask = new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false };

           _mockTaskRepository
               .Setup(repo => repo.GetById(1))
               .Returns(mockTask);

           
           var result = _taskService.GetTaskById(1);

           Assert.NotNull(result);
           Assert.Equal("Task 1", result.Title);
           _mockTaskRepository.Verify(repo => repo.GetById(1), Times.Once);
       }

       [Fact]
        public void GetTaskById_Throws_Exception_If_Not_Found()
        {
            
            _ = _mockTaskRepository
                .Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns(default(TaskItem));

            Assert.Throws<KeyNotFoundException>(() => _taskService.GetTaskById(999));
            _mockTaskRepository.Verify(repo => repo.GetById(999), Times.Once);
        }

       [Fact]
        public void AddTask_Calls_Repository_Add_Method()
        {
            
            var taskDto = new TaskDto
            {
                Title = "New Task",
                Description = "New Description",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(1)
            };

           
            _taskService.CreateTask(taskDto);

            
            _mockTaskRepository.Verify(repo => repo.Add(It.IsAny<TaskItem>()), Times.Once);
        }

       [Fact]
        public void UpdateTask_Calls_Repository_Update_Method()
        {
            
            var taskDto = new TaskDto
            {
                Id = 1,
                Title = "Updated Task",
                Description = "Updated Description",
                IsCompleted = true,
                DueDate = DateTime.Now.AddDays(5)
            };

            _mockTaskRepository
                .Setup(repo => repo.GetById(1))
                .Returns(new TaskItem
                {
                    Id = 1,
                    Title = "Old Task",
                    Description = "Old Description",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(1)
                });

            
            _taskService.UpdateTask(1, taskDto);

            _mockTaskRepository.Verify(repo => repo.Update(It.IsAny<TaskItem>()), Times.Once);
        }

       [Fact]
       public void DeleteTask_Calls_Repository_Delete_Method()
       {
           var taskId = 1;

           _mockTaskRepository
               .Setup(repo => repo.GetById(taskId))
               .Returns(new TaskItem { Id = 1, Title = "Old Task", Description = "Old Description", IsCompleted = false });

           _taskService.DeleteTask(taskId);

           _mockTaskRepository.Verify(repo => repo.Delete(taskId), Times.Once);
       }
   }
}

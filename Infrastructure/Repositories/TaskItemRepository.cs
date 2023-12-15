using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Domain;
using CQRS.Practice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practice.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDto> CreateTask(string Title, string Description, bool? IsCompleted)
        {
            TaskItem taskItem = new TaskItem
            {
                Title = Title,
                Description = Description,
                IsCompleted = IsCompleted ?? false
            };

            _dbContext.TaksItems.Add(taskItem);
            await _dbContext.SaveChangesAsync();

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }

        public async Task<bool> DeleteTask(int id)
        {
            var taskToDelete = _dbContext.TaksItems.FirstOrDefault(t => t.Id == id);

            if (taskToDelete != null)
            {
                _dbContext.TaksItems.Remove(taskToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TaskItemDto> UpdateTask(int id, string? Title, string? Description)
        {
            var existingTaskItem = await _dbContext.TaksItems.FindAsync(id) ?? throw new InvalidOperationException("Task not found");

            existingTaskItem.Title = Title ?? existingTaskItem.Title;
            existingTaskItem.Description = Description ?? existingTaskItem.Description;

            await _dbContext.SaveChangesAsync();

            return new TaskItemDto
            {
                Title = existingTaskItem.Title,
                Description = existingTaskItem.Description
            };
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllTask()
        {
            var allTaskItems = await _dbContext.TaksItems.ToListAsync();

            return allTaskItems.Select(taskItem => new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            });
        }

        public async Task<TaskItemDto> GetTaskById(int id)
        {
            var taskItem = await _dbContext.TaksItems.FindAsync(id) ?? throw new InvalidOperationException("Task not found");

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }

    }
}
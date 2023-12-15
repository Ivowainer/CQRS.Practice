using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Domain;
using CQRS.Practice.Infrastructure.Data;

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

        public bool DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskItemDto>> GetAllTask()
        {

            throw new NotImplementedException();
        }

        public Task<TaskItemDto> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemDto> UpdateTask(int id, string? Title, string? Description)
        {
            throw new NotImplementedException();
        }
    }
}
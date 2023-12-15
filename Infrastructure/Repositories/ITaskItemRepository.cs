using CQRS.Practice.Application.DTOs;

namespace CQRS.Practice.Infrastructure.Repositories
{
    public interface ITaskItemRepository
    {
        public Task<TaskItemDto> CreateTask(string Title, string Description, bool? IsCompleted);
        public Task<TaskItemDto> UpdateTask(int id, string? Title, string? Description);
        public Task<bool> DeleteTask(int id);
        public Task<TaskItemDto> GetTaskById(int id);
        public Task<IEnumerable<TaskItemDto>> GetAllTask();
    }
}
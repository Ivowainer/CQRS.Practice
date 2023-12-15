using CQRS.Practice.Application.DTOs;

namespace CQRS.Practice.Infrastructure.Repositories
{
    public interface ITaskItemRepository
    {
        public TaskItemDto CreateTask(string Title, string Description, bool? IsCompleted);
        public TaskItemDto UpdateTask(int id, string? Title, string? Description);
        public bool DeleteTask(int id);
        public TaskItemDto GetTaskById(int id);
        public IEnumerable<TaskItemDto> GetAllTask();
    }
}
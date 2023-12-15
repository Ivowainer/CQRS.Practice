using CQRS.Practice.Application.DTOs;

namespace CQRS.Practice.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        public TaskItemDto CreateTask(string Title, string Description, bool? IsCompleted)
        {
            throw new NotImplementedException();
        }

        public TaskItemDto UpdateTask(int id, string? Title, string? Description)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public TaskItemDto GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskItemDto> GetAllTask()
        {
            throw new NotImplementedException();
        }
    }
}
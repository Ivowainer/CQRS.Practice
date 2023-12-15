using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Infrastructure.Commands;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class CreateTaskHandle : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public CreateTaskHandle(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return _taskItemRepository.CreateTask(request.Title, request.Description, false);
        }
    }
}
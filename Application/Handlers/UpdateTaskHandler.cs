using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Infrastructure.Commands;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public UpdateTaskHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return _taskItemRepository.UpdateTask(request.Id, request.Title, request.Description);
        }
    }
}
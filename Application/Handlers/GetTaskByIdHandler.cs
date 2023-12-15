using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Infrastructure.Queries;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public GetTaskByIdHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return _taskItemRepository.GetTaskById(request.Id);
        }
    }
}
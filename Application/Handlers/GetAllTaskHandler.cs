using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Infrastructure.Queries;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public GetAllTaskHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
using CQRS.Practice.Infrastructure.Commands;
using CQRS.Practice.Infrastructure.Data;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public DeleteTaskHandler(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return _taskItemRepository.DeleteTask(request.Id);
        }
    }
}
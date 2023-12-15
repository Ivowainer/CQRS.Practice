using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Infrastructure.Commands;
using MediatR;

namespace CQRS.Practice.Application.Handlers
{
    public class CreateTaskHandle : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        public Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
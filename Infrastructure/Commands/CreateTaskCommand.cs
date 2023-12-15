using CQRS.Practice.Application.DTOs;
using MediatR;

namespace CQRS.Practice.Infrastructure.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;
}
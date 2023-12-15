using MediatR;

namespace CQRS.Practice.Infrastructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
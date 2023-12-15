using CQRS.Practice.Application.DTOs;
using MediatR;

namespace CQRS.Practice.Infrastructure.Queries
{
    public record GetAllTaskQuery : IRequest<IEnumerable<TaskItemDto>>;
}
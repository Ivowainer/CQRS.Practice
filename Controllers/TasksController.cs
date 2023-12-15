using CQRS.Practice.Application.DTOs;
using CQRS.Practice.Domain;
using CQRS.Practice.Infrastructure.Commands;
using CQRS.Practice.Infrastructure.Queries;
using CQRS.Practice.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITaskItemRepository _taskItemRepository;
        public TasksController(IMediator mediator, ITaskItemRepository taskItemRepository)
        {
            _mediator = mediator;
            _taskItemRepository = taskItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTaskQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var taskItem = await _mediator.Send(query);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> Create(CreateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = taskItem.Id }, taskItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest();
            }

            var taskItem = await _mediator.Send(command);
            if (taskItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
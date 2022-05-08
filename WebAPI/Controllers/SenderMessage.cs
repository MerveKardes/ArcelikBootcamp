
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Application.CQRS.Queries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SenderMessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SenderMessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSenderMessages()
        {
            var result = await _mediator.Send(new GetSenderMessageListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetSenderMessageByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateSenderMessageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSenderMessage(int id)
        {
            await _mediator.Send(new RemoveSenderMessageCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSenderMessage([FromBody] CreateSenderMessageCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}

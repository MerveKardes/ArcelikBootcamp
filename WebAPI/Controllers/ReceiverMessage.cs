
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Application.CQRS.Queries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiverMessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReceiverMessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiverMessages()
        {
            var result = await _mediator.Send(new GetReceiverMessageListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetReceiverMessageByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateReceiverMessageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReceiverMessage(int id)
        {
            await _mediator.Send(new RemoveReceiverMessageCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceiverMessage([FromBody] CreateReceiverMessageCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Application.CQRS.Queries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilms()
        {
            var result = await _mediator.Send(new GetFilmListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetFilmByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilm([FromBody] UpdateFilmCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFilm(int id)
        {
            await _mediator.Send(new RemoveFilmCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] CreateFilmCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}

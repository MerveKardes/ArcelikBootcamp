using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Application.CQRS.Queries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _mediator.Send(new GetMovieListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            await _mediator.Send(new RemoveMovieCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}

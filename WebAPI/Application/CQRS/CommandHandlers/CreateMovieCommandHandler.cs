using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly Context _context;

        public CreateMovieCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var createdMovie=new Movie();
            createdMovie.Name=request.Name;
            createdMovie.Summary=request.Summary;
            createdMovie.Director=request.Director;
            createdMovie.Point=request.Point;
            createdMovie.IsFavorite=request.IsFavorite;

            await _context.Movies.AddAsync(createdMovie);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

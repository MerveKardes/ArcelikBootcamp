using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly Context _context;

        public UpdateMovieCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var updatedMovie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedMovie != null)
            {
                updatedMovie.Name = request.Name;
                updatedMovie.Summary = request.Summary;
                updatedMovie.Director = request.Director;
                updatedMovie.Point = request.Point;
                updatedMovie.IsFavorite = request.IsFavorite;

                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommand>
    {
        private readonly Context _context;

        public RemoveMovieCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
        {
            var removedMovie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(removedMovie != null)
            {
                _context.Movies.Remove(removedMovie);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}

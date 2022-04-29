using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveFilmCommandHandler : IRequestHandler<RemoveFilmCommand>
    {
        private readonly Context _context;

        public RemoveFilmCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveFilmCommand request, CancellationToken cancellationToken)
        {
            var removedFilm = await _context.Films.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(removedFilm != null)
            {
                _context.Films.Remove(removedFilm);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}

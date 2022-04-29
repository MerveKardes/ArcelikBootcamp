using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
    {
        private readonly Context _context;

        public UpdateFilmCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var updatedFilm = await _context.Films.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedFilm != null)
            {
                updatedFilm.Name = request.Name;
                updatedFilm.Summary = request.Summary;
                updatedFilm.Director = request.Director;
                updatedFilm.Point = request.Point;
                updatedFilm.IsFavorite = request.IsFavorite;

                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand>
    {
        private readonly Context _context;

        public CreateFilmCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var createdFilm=new Film();
            createdFilm.Name=request.Name;
            createdFilm.Summary=request.Summary;
            createdFilm.Director=request.Director;
            createdFilm.Point=request.Point;
            createdFilm.IsFavorite=request.IsFavorite;

            await _context.Films.AddAsync(createdFilm);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

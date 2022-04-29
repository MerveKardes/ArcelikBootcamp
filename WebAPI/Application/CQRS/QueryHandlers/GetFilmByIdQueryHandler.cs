using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDto?>
    {
        private readonly Context _context;

        public GetFilmByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<FilmDto?> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Films.AsNoTracking().Select(x => new FilmDto
            {
                Id = x.Id,
                Name = x.Name,
                Summary=x.Summary,
                Director=x.Director,
                Point=x.Point,
                
            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

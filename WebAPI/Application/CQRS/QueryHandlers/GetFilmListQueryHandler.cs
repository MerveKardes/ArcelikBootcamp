using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetFilmListQueryHandler : IRequestHandler<GetFilmListQuery, List<FilmDto>>
    {
        private readonly Context _context;

        public GetFilmListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<FilmDto>> Handle(GetFilmListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Films.AsNoTracking().Select(x => new FilmDto
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Summary,
                Director = x.Director,
                Point = x.Point,

            }).ToListAsync();

            return result;
        }
    }
}

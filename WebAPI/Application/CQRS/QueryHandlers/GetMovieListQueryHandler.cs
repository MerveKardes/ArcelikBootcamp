using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
    {
        private readonly Context _context;

        public GetMovieListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Movies.AsNoTracking().Select(x => new MovieDto
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

using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto?>
    {
        private readonly Context _context;

        public GetMovieByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<MovieDto?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Movies.AsNoTracking().Select(x => new MovieDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl=x.ImageUrl,
                Summary=x.Summary,
                Director=x.Director,
                Point=x.Point,
                IsFavorite=x.IsFavorite
                
            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

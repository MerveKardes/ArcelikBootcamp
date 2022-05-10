using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        private readonly Context _context;

        public GetBookByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Books.AsNoTracking().Select(x => new BookDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Writer = x.Writer,
                Point = x.Point,

            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

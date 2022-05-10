using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, List<BookDto>>
    {
        private readonly Context _context;

        public GetBookListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<BookDto>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Books.AsNoTracking().Select(x => new BookDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Writer = x.Writer,
                Point = x.Point,

            }).ToListAsync();

            return result;
        }
    }
}

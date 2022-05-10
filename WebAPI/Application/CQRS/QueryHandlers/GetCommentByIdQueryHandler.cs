using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
    {
        private readonly Context _context;

        public GetCommentByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Comments.AsNoTracking().Select(x => new CommentDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId=x.UserId,
                BookId=x.BookId,
                MovieId=x.MovieId,  
                Date=x.Date,

            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

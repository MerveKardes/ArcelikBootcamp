using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<MovieDto>>
    {
        private readonly Context _context;

        public GetCommentListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<CommentDto>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Comments.AsNoTracking().Select(x => new CommentDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId=x.UserId,
                BookId=x.BookId,
                MovieId=x.MovieId
                Date=x.Date,

            }).ToListAsync();

            return result;
        }
  Comment
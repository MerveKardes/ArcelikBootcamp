using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly Context _context;

        public CreateCommentCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommandHandler request, CancellationToken cancellationToken)
        {
            var CreateComment=new Comment();
            CreateComment.Content=request.Content;
            CreateComment.UserId=request.UserId;
            CreateComment.BookId=request.BookId;
            CreateComment.MovieId=request.MovieId;
            CreateComment.User=request.User;
            CreateComment.Book=request.Book;
            CreateComment.Movie=request.Movie;
            CreateComment.Date=request.Date;

            await _context.Comment.AddAsync(CreateComment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

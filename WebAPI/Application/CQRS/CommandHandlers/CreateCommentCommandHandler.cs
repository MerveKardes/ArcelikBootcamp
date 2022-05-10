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

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var createdComment=new Comment();
            createdComment.Content=request.Content;
            createdComment.UserId=request.UserId;
            createdComment.BookId=request.BookId;
            createdComment.MovieId=request.MovieId;
            createdComment.Date=request.Date;

            await _context.Comments.AddAsync(createdComment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

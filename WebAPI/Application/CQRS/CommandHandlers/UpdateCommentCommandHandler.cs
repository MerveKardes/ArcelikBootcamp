using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly Context _context;

        public UpdateCommentCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var updatedComment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedComment != null)
            {
                updatedComment.Content=request.Content;
                updatedComment.UserId=request.UserId;
                updatedComment.BookId=request.BookId;
                updatedComment.MovieId=request.MovieId;
                updatedComment.Date=request.Date;

                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

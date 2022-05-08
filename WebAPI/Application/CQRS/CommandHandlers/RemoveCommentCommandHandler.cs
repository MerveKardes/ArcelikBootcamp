using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly Context _context;

        public RemoveCommentCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveCommentCommandHandler request, CancellationToken cancellationToken)
        {
            var removedComment = await _context.Comment.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(removedComment != null)
            {
                _context.Comment.Remove(removedComment);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}

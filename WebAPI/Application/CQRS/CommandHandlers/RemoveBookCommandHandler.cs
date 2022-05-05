using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand>
    {
        private readonly Context _context;

        public RemoveBookCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var removedBook = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedBook != null)
            {
                _context.Books.Remove(removedBook);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}

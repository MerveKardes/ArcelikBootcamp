using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly Context _context;

        public UpdateBookCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var updatedBook = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedBook != null)
            {
                updatedBook.Name = request.Name;
                updatedBook.Writer = request.Writer;
                updatedBook.Point = request.Point;
                updatedBook.IsFavorite = request.IsFavorite;

                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

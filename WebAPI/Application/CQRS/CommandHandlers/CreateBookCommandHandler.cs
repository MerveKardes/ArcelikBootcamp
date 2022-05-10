using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly Context _context;

        public CreateBookCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var createdBook = new Book();
            createdBook.Name = request.Name;
            createdBook.Writer = request.Writer;
            createdBook.ImageUrl = request.ImageUrl;
            createdBook.Point = request.Point;
            createdBook.IsFavorite = request.IsFavorite;

            await _context.Books.AddAsync(createdBook);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

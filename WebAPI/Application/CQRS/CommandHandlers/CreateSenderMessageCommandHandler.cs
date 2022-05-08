
using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateSenderMessageCommandHandler : IRequestHandler<CreateSenderMessageCommand>
    {
        private readonly Context _context;

        public CreateSenderMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSenderMessageCommand request, CancellationToken cancellationToken)
        {
            var createdSenderMessage = new SenderMessage();
            createdSenderMessage.Content = request.Content;
            createdSenderMessage.UserId = request.UserId;

            await _context.SenderMessages.AddAsync(createdSenderMessage);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

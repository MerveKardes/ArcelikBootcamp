
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveSenderMessageCommandHandler : IRequestHandler<RemoveSenderMessageCommand>
    {
        private readonly Context _context;

        public RemoveSenderMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveUserCommand command)
        {
            var removedSenderMessage = _context.SenderMessages.SingleOrDefault(x => x.Id == command.Id);
            if (removedSenderMessage != null)
            {
                _context.SenderMessages.Remove(removedSenderMessage);
                _context.SaveChanges();
            }

        }

        public async Task<Unit> Handle(RemoveSenderMessageCommand request, CancellationToken cancellationToken)
        {
            var removedSenderMessage = await _context.SenderMessages.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedSenderMessage != null)
            {
                _context.SenderMessages.Remove(removedSenderMessage);
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}


using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class RemoveReceiverMessageCommandHandler : IRequestHandler<RemoveReceiverMessageCommand>
    {
        private readonly Context _context;

        public RemoveReceiverMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveUserCommand command)
        {
            var removedReceiverMessage = _context.ReceiverMessages.SingleOrDefault(x => x.Id == command.Id);
            if (removedReceiverMessage != null)
            {
                _context.ReceiverMessages.Remove(removedReceiverMessage);
                _context.SaveChanges();
            }

        }

        public async Task<Unit> Handle(RemoveReceiverMessageCommand request, CancellationToken cancellationToken)
        {
            var removedReceiverMessage = await _context.ReceiverMessages.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedReceiverMessage != null)
            {
                _context.ReceiverMessages.Remove(removedReceiverMessage);
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}


using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateReceiverMessageCommandHandler : IRequestHandler<UpdateReceiverMessageCommand>
    {
        private readonly Context _context;

        public UpdateReceiverMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReceiverMessageCommand request, CancellationToken cancellationToken)
        {
            var updatedReceiverMessage = await _context.ReceiverMessages.FindAsync(request.Id);
            if (updatedReceiverMessage != null)
            {
                updatedReceiverMessage.Content = request.Content;
                updatedReceiverMessage.UserId = request.UserId;
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}

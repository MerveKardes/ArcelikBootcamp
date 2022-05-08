
using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class CreateReceiverMessageCommandHandler : IRequestHandler<CreateReceiverMessageCommand>
    {
        private readonly Context _context;

        public CreateReceiverMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateReceiverMessageCommand request, CancellationToken cancellationToken)
        {
            var createdReceiverMessage = new ReceiverMessage();
            createdReceiverMessage.Content = request.Content;
            createdReceiverMessage.UserId = request.UserId;

            await _context.ReceiverMessages.AddAsync(createdReceiverMessage);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

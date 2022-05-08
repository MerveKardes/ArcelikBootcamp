
using MediatR;
using WebAPI.Application.CQRS.Commands;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.CommandHandlers
{
    public class UpdateSenderMessageCommandHandler : IRequestHandler<UpdateSenderMessageCommand>
    {
        private readonly Context _context;

        public UpdateSenderMessageCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSenderMessageCommand request, CancellationToken cancellationToken)
        {
            var updatedSenderMessage = await _context.SenderMessages.FindAsync(request.Id);
            if (updatedSenderMessage != null)
            {
                updatedSenderMessage.Content = request.Content;
                updatedSenderMessage.UserId = request.UserId;
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}

using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveReceiverMessageCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveReceiverMessageCommand(int id)
        {
            Id = id;
        }
    }
}

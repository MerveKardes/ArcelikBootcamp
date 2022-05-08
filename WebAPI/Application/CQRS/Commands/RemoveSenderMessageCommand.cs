using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveSenderMessageCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSenderMessageCommand(int id)
        {
            Id = id;
        }
    }
}

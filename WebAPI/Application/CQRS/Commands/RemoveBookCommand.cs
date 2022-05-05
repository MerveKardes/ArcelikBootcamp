using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveBookCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveBookCommand(int id)
        {
            Id = id;
        }
    }
}

using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveFilmCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveFilmCommand(int id)
        {
            Id = id;
        }

        

    }
}

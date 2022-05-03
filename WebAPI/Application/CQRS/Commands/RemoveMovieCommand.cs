using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveMovieCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveMovieCommand(int id)
        {
            Id = id;
        }

        

    }
}

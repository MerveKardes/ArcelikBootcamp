using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class RemoveCommentCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveCommentCommand(int id)
        {
            Id = id;
        }
using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class CreateSenderMessageCommand : IRequest
    {
        //[Required]
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int? UserId { get; set; }
    }
}

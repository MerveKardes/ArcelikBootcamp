using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class CreateCommentCommand:IRequest
    {
      public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int MovieId { get; set; }
        public DateTime Date {get; set; }
    }
}

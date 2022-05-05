using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}

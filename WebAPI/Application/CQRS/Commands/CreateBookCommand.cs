using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class CreateBookCommand : IRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Writer { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}

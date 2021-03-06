using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class CreateMovieCommand:IRequest
    {
        public string Name { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Summary { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}

using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetMovieByIdQuery:IRequest<MovieDto?>
    {
        public int Id { get; set; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }
}

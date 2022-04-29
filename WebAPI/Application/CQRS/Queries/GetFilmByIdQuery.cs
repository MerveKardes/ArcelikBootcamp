using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetFilmByIdQuery:IRequest<FilmDto?>
    {
        public int Id { get; set; }

        public GetFilmByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetFilmListQuery:IRequest<List<FilmDto>>
    {
    }
}

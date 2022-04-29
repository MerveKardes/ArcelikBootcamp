
using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetUserListQuery : IRequest<List<UserDto>>
    {
    }
}

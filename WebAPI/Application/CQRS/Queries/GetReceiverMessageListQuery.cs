
using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetReceiverMessageListQuery : IRequest<List<ReceiverMessageDto>>
    {
    }
}

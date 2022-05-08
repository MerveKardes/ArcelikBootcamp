
using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetReceiverMessageByIdQuery : IRequest<ReceiverMessageDto?>
    {
        public int Id { get; set; }

        public GetReceiverMessageByIdQuery(int id)
        {
            Id = id;
        }
    }
}

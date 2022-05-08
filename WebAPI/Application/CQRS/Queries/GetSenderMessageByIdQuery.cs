
using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetSenderMessageByIdQuery : IRequest<SenderMessageDto?>
    {
        public int Id { get; set; }

        public GetSenderMessageByIdQuery(int id)
        {
            Id = id;
        }
    }
}

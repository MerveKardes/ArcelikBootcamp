using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetReceiverMessageListQueryHandler : IRequestHandler<GetReceiverMessageListQuery, List<ReceiverMessageDto>>
    {
        private readonly Context _context;

        public GetReceiverMessageListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<ReceiverMessageDto>> Handle(GetReceiverMessageListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ReceiverMessages.AsNoTracking().Select(x => new ReceiverMessageDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId = x.UserId,

            }).ToListAsync();

            return result;
        }
    }
}

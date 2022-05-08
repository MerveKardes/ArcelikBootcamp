using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetSenderMessageListQueryHandler : IRequestHandler<GetSenderMessageListQuery, List<SenderMessageDto>>
    {
        private readonly Context _context;

        public GetSenderMessageListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<SenderMessageDto>> Handle(GetSenderMessageListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.SenderMessages.AsNoTracking().Select(x => new SenderMessageDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId = x.UserId

            }).ToListAsync();

            return result;
        }
    }
}

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
            var result2 = await _context.SenderMessages.Join(_context.Users, message => message.UserId, user => user.Id, (message, user) => new { user, message })
                .Select(x => new SenderMessageDto { Id = x.message.Id, UserId = x.message.UserId, Content = x.message.Content, Username = x.user.Username }).ToListAsync();


            return result2;
        }
    }
}

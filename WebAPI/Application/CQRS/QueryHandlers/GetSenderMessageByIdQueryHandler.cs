using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetSenderMessageByIdQueryHandler : IRequestHandler<GetSenderMessageByIdQuery, SenderMessageDto?>
    {
        private readonly Context _context;

        public GetSenderMessageByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<SenderMessageDto?> Handle(GetSenderMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.SenderMessages.AsNoTracking().Select(x => new SenderMessageDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId = x.UserId,

            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

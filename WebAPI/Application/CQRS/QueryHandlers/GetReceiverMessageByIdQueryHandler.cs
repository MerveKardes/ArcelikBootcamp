using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetReceiverMessageByIdQueryHandler : IRequestHandler<GetReceiverMessageByIdQuery, ReceiverMessageDto?>
    {
        private readonly Context _context;

        public GetReceiverMessageByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<ReceiverMessageDto?> Handle(GetReceiverMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ReceiverMessages.AsNoTracking().Select(x => new ReceiverMessageDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId = x.UserId,


            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}

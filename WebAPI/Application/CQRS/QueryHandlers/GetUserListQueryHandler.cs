
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.CQRS.Queries;
using WebAPI.Application.Dtos;
using WebAPI.Data.Context;
using WebAPI.Data.Entities;

namespace WebAPI.Application.CQRS.QueryHandlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly Context _context;

        public GetUserListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _context.Users.OfType<User>().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                Message = x.Message,
                RoleId = x.RoleId,
            }).AsNoTracking().ToListAsync();

            return userList;
        }
    }
}

using MediatR;
using WebAPI.Application.Dtos;

namespace WebAPI.Application.CQRS.Queries
{
    public class GetCommentListQuery:IRequest<List<CommentDto>>
    {
    }
}

using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Queries.UserQueries
{
    public record GetUserByIdQuery
        (
            int Id
        )
        : IRequest<Response<UserResponse>>;
}

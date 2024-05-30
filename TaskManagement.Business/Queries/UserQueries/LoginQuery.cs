using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Queries.UserQueries
{
    public record LoginQuery
        (
            string Email,
            string Password
        )
        : IRequest<Response<LoginResponse>>;
}

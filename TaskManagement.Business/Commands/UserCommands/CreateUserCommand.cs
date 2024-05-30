using MediatR;
using TaskManagement.Business.Shared;

namespace TaskManagement.Business.Commands.UserCommands
{
    public record CreateUserCommand
        (
        int RoleId,
        string Name,
        string Surname,
        string Email,
        string Password
        )
        : IRequest<Response<bool>>;
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.Shared;

namespace TaskManagement.Business.Commands.RoleCommands
{
    public record CreateRoleCommand
        (
        string Name
        )
        : IRequest<Response<bool>>;
}

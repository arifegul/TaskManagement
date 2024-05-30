using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.Shared;

namespace TaskManagement.Business.Commands.TaskCommands
{
    public record UpdateTaskStatusCommand
        (
        int TaskId,
        int TaskStatus
        )
        : IRequest<Response<bool>>;
}

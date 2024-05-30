using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Commands.TaskCommands
{
    public record CreateTaskCommand
        (
        int UserId,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate
        )
        : IRequest<Response<TaskResponse>>;
}

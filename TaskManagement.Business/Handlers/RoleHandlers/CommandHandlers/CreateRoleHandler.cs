using MediatR;
using TaskManagement.Business.Commands.RoleCommands;
using TaskManagement.Business.Repositories.RoleRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Entities;

namespace TaskManagement.Business.Handlers.RoleHandlers.CommandHandlers
{
    public class CreateRoleHandler(IRoleWriteRepository repository) : IRequestHandler<CreateRoleCommand, Response<bool>>
    {
        private readonly IRoleWriteRepository _repository = repository;
        public async Task<Response<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = new()
            {
                Name = request.Name
            };

            var isCreated = await _repository.Create(role) >= 1;
            if (!isCreated)
                return Response<bool>.Fail("Error while creating", 409);

            return Response<bool>.Success(isCreated, 201);
        }
    }
}

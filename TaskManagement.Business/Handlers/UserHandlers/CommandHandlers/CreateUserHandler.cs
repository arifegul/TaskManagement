using FluentValidation.Results;
using MediatR;
using TaskManagement.Business.Commands.UserCommands;
using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Business.Validators;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;

namespace TaskManagement.Business.Handlers.UserHandlers.CommandHandlers
{
    public class CreateUserHandler(IUserWriteRepository repository) : IRequestHandler<CreateUserCommand, Response<bool>>
    {
        private readonly IUserWriteRepository _repository = repository;
        public async Task<Response<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                CreatedBy = "System",
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                RoleId = request.RoleId
            };

            UserValidator validationRules = new();
            ValidationResult validationResult = validationRules.Validate(user);
        
            if (!validationResult.IsValid)
                return Response<bool>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList(), 409);

            var isCreated = await _repository.Create(user) >= 1;

            if (!isCreated)
                return Response<bool>.Fail("User cannot created!", 409);

            return Response<bool>.Success(isCreated, 201);
        }
    }
}

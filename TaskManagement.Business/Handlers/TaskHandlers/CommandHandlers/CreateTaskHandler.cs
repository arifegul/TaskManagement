using AutoMapper;
using FluentValidation.Results;
using MediatR;
using TaskManagement.Business.Commands.TaskCommands;
using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Business.Validators;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.TaskHandlers.CommandHandlers
{
    public class CreateTaskHandler(ITaskWriteRepository repository, ITaskDetailWriteRepository detailRepository, IMapper mapper) : IRequestHandler<CreateTaskCommand, Response<TaskResponse>>
    {
        private readonly ITaskWriteRepository _repository = repository;
        private readonly ITaskDetailWriteRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<TaskResponse>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var getUser = await TaskManagementAPIs.GetUserById<UserResponse>(request.UserId);
            if (getUser == null)
                return Response<TaskResponse>.Fail("User cannot found!", 409);

            Tasks task = new()
            {
                Name = request.Name,
                UserId = request.UserId,
                CreatedBy = "Arife Gül Yalçın"
            };

            TaskDetail taskDetail = new()
            {
                Task = task,
                CreatedBy = "Arife Gül Yalçın",
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TaskId = task.Id
            };

            TaskValidator validationRules = new();
            ValidationResult validationResult = validationRules.Validate(taskDetail);

            if (!validationResult.IsValid)
                return Response<TaskResponse>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList(), 409);

            bool isCreated;

            isCreated = await _repository.Create(task) >= 1;
            if (!isCreated)
                return Response<TaskResponse>.Fail("Error while creating", 409);

            isCreated = await _detailRepository.Create(taskDetail) >= 1;
            if (!isCreated)
                return Response<TaskResponse>.Fail("Error while creating", 409);

            TaskResponse response = new()
            {
                Name = task.Name,
                TaskDetail = _mapper.Map<TaskDetailResponse>(taskDetail),
                User = _mapper.Map<UserResponse>(getUser)
            };

            return Response<TaskResponse>.Success(response, 201);
        }
    }
}

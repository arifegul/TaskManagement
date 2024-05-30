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
    public class UpdateTaskHandler(ITaskWriteRepository repository, ITaskDetailWriteRepository detailRepository, IMapper mapper) : IRequestHandler<UpdateTaskCommand, Response<TaskResponse>>
    {
        private readonly ITaskWriteRepository _repository = repository;
        private readonly ITaskDetailWriteRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<TaskResponse>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var getTaskResponse = await TaskManagementAPIs.GetTaskById<TaskResponse>(request.TaskId);
            if (getTaskResponse == null)
                return Response<TaskResponse>.Fail("Task could not found!", 409);

            bool isUpdated;

            var getTask = _mapper.Map<Tasks>(getTaskResponse);
            var getUser = _mapper.Map<User>(getTaskResponse.User);

            var getTaskDetail = _mapper.Map<TaskDetail>(getTaskResponse.TaskDetail);

            getTaskDetail.StartDate = request.StartDate;
            getTaskDetail.EndDate = request.EndDate;
            getTaskDetail.Description = request.Description;
            getTaskDetail.TaskId = getTask.Id;

            TaskValidator validationRules = new();
            ValidationResult validationResult = validationRules.Validate(getTaskDetail);

            if (!validationResult.IsValid)
                return Response<TaskResponse>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList(), 409);

            getTask.Name = request.Name;
            getTask.User = getUser;

            isUpdated = await _repository.Update(getTask) >= 1;
            if (!isUpdated)
                return Response<TaskResponse>.Fail("Error while updating", 409);

            isUpdated = await _detailRepository.Update(getTaskDetail) >= 1;
            if (!isUpdated)
                return Response<TaskResponse>.Fail("Error while updating", 409);

            TaskResponse response = new()
            {
                Id = getTask.Id,
                Name = getTask.Name,
                Status = getTask.Status,
                CreatedBy = getTask.CreatedBy,
                CreatedDate = getTask.CreatedDate,
                ModifiedBy = getTask.ModifiedBy,
                ModifiedDate = getTask.ModifiedDate,
                TaskDetail = _mapper.Map<TaskDetailResponse>(getTaskDetail),
                User = getTaskResponse.User
            };

            return Response<TaskResponse>.Success(response, 201);
        }
    }
}

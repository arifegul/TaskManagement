using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.TaskDetailRepositories
{
    public class TaskDetailWriteRepository(TaskManagementDbContext dbContext) : WriteRepository<TaskDetail>(dbContext), ITaskDetailWriteRepository
    {
	}
}

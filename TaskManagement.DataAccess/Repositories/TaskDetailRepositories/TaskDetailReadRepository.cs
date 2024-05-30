using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.TaskDetailRepositories
{
    public class TaskDetailReadRepository(TaskManagementDbContext dbContext) : ReadRepository<TaskDetail>(dbContext), ITaskDetailReadRepository
	{
	}
}

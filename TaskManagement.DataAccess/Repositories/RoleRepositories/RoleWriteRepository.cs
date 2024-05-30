using TaskManagement.Business.Repositories.RoleRepositories;
using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.RoleRepositories
{
    public class RoleWriteRepository(TaskManagementDbContext dbContext) : WriteRepository<Role>(dbContext), IRoleWriteRepository
    {
	}
}

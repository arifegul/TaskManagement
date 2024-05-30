using TaskManagement.Business.Repositories.RoleRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.RoleRepositories
{
    public class RoleReadRepository(TaskManagementDbContext dbContext) : ReadRepository<Role>(dbContext), IRoleReadRepository
    {
	}
}

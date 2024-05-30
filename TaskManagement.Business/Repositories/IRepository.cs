using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Business.Repositories
{
    public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}

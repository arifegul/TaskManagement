using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Business.Repositories 
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<int> Create(T entity);
		Task<int> Delete(T entity);
		Task<int> Update(T entity);
	}
}

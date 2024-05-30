using System.Linq.Expressions;
using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.Business.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAll();
		Task<List<T>> GetAllIncluding(params Expression<Func<T, object>>[] includes);
		Task<T> Find(Expression<Func<T, bool>> expression);
	}
}

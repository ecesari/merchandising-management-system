using System.Collections.Generic;
using System.Threading.Tasks;
using MerchandisingManagement.Domain.Entities;
using MerchandisingManagement.Domain.Specifications;

namespace MerchandisingManagement.Domain.Repositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		//Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
		//Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
		//	Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		//	string includeString = null,
		//	bool disableTracking = true);
		//Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
		//	Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		//	List<Expression<Func<T, object>>> includes = null,
		//	bool disableTracking = true);
		Task<IReadOnlyList<T>> GetAsync(IBaseSpecification<T> spec);
		Task<T> GetByIdAsync(int id);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		//Task<int> CountAsync(IBaseSpecification<T> spec);


	}
}

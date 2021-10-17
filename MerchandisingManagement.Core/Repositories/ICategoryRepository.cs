using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
	interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<Category> GetCategoryWithProductsAsync(int categoryId);

	}
}

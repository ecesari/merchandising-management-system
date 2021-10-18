using System.Threading.Tasks;
using MerchandisingManagement.Domain.Entities;

namespace MerchandisingManagement.Domain.Repositories
{
	interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<Category> GetCategoryWithProductsAsync(int categoryId);

	}
}

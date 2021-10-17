using MerchandisingManagement.Domain.Entities;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Infrastructure.Data;
using MerchandisingManagement.Infrastructure.Repository.Base;

namespace MerchandisingManagement.Infrastructure.Repository
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(MerchandisingManagementContext merchandisingManagementContext) : base(merchandisingManagementContext)
		{
			
		}


	}
}

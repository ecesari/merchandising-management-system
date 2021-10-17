using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Domain.Specifications.Product;
using Infrastructure.Data;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(MerchandisingManagementContext merchandisingManagementContext) : base(merchandisingManagementContext)
		{
			
		}


	}
}

using System;
using System.Linq.Expressions;

namespace MerchandisingManagement.Domain.Specifications.Product
{
	public class HasStockOfCategorySpecification : BaseSpecification<Entities.Product>
	{
		public HasStockOfCategorySpecification(Expression<Func<Entities.Product, bool>> criteria) : base(p => p.CategoryId != null && p.StockQuantity >= p.Category.MinimumStockQuantity)
		{
			AddInclude(p => p.Category);
		}
	}


}

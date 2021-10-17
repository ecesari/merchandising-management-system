using System;
using System.Linq.Expressions;

namespace Domain.Specifications.Product
{
	public class HasCategorySpecification : BaseSpecification<Entities.Product>
	{
		public HasCategorySpecification(Expression<Func<Entities.Product, bool>> criteria) : base(p => p.CategoryId != null)
		{
			AddInclude(p => p.Category);

		}
	}


}

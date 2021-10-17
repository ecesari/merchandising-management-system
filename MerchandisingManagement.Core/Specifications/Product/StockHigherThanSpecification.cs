using System;
using System.Linq.Expressions;

namespace Domain.Specifications.Product
{
	public class StockHigherThanSpecification : BaseSpecification<Entities.Product>
	{
		public StockHigherThanSpecification(int threshold) : base(p=>p.StockQuantity > threshold)
		{
		}
	}
}

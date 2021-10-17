namespace MerchandisingManagement.Domain.Specifications.Product
{
	public class StockLowerThanSpecification : BaseSpecification<Entities.Product>
	{
		public StockLowerThanSpecification(int threshold) : base(p => p.StockQuantity < threshold)
		{
		}

	}
}

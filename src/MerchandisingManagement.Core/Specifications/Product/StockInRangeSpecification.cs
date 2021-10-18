namespace MerchandisingManagement.Domain.Specifications.Product
{
	public class StockInRangeSpecification : BaseSpecification<Entities.Product>
	{
		public StockInRangeSpecification(int minVal,int maxVal) : base(p=>p.StockQuantity > minVal && p.StockQuantity < maxVal)
		{
		}
	}
}

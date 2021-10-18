namespace MerchandisingManagement.Domain.Specifications.Product
{
	public class HasSearchKeywordSpecification : BaseSpecification<Entities.Product>
	{
		public HasSearchKeywordSpecification(string keyword) : base(p => p.Title.Contains(keyword) || p.Description.Contains(keyword) || (p.Category != null && p.Category.Name.Contains(keyword)))
		{
		}
	}
}

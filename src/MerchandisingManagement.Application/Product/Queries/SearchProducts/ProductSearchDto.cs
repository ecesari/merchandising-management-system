namespace MerchandisingManagement.Application.Product.Queries.SearchProducts
{
	public class ProductSearchDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public int CategoryId { get; set; }
	}
}

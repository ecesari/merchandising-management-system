namespace MerchandisingManagement.Application.Product.Queries.GetProducts
{
	public class GetProductsDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
	}
}

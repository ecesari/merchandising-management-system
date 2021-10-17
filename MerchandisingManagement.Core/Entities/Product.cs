namespace Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public int? CategoryId { get; set; }
		public Category Category { get; set; }

		public static Product Create(int id, string title, string description, int stockQuantity, int? categoryId = null)
		{
			return new Product
			{
				Id = id,
				CategoryId = categoryId,
				Description = description,
				Title = title,
				StockQuantity = stockQuantity
			};
		}
	}

}

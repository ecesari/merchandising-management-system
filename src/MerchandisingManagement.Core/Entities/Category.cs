using System.Collections.Generic;

namespace MerchandisingManagement.Domain.Entities
{
	public class Category : BaseEntity
	{
		public Category()
		{
			Products = new HashSet<Product>();
		}
		public string Name { get; set; }
		public int MinimumStockQuantity { get; set; }
		public ICollection<Product> Products { get; set; }


		public static Category Create(int id, string name, int minimumStockQuantity)
		{
			return new Category
			{
				Id = id,
				Name = name,
				MinimumStockQuantity = minimumStockQuantity
			};
		}
	}
}


using MerchandisingManagement.Domain.Entities;
using Xunit;

namespace MerchandisingManagement.Domain.UnitTests.Entities
{
	public class ProductTests
	{
		private int _id = 1;
		private int _categoryId = 2;
		private string _title = "Sample Product";
		private string _description = "Sample Product Description";
		private int _stockQuantity = 250;

		[Fact]
		public void Create_Product()
		{
			var product = Product.Create(_id, _title,_description,_stockQuantity, _categoryId);

			Assert.Equal(_id, product.Id);
			Assert.Equal(_title,product.Title);
			Assert.Equal(_description,product.Description);
			Assert.Equal(_categoryId,product.CategoryId);
			Assert.Equal(_stockQuantity,product.StockQuantity);
		}
    }
}

using Domain.Entities;
using Xunit;

namespace Domain.UnitTests.Entities
{
	public class CategoryTests
	{
		private int _id = 1;
		private string _name = "Sample Category";
		private int _minimumStockQuantity = 20;

		[Fact]
		public void Create_Category()
		{
			var product = Category.Create(_id, _name,_minimumStockQuantity);

			Assert.Equal(_id, product.Id);
			Assert.Equal(_name, product.Name);
			Assert.Equal(_minimumStockQuantity, product.MinimumStockQuantity);
		}
    }
}

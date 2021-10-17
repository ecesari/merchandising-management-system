using System.Collections.Generic;
using System.Linq;
using MerchandisingManagement.Domain.Entities;
using MerchandisingManagement.Domain.Specifications.Product;
using Xunit;

namespace MerchandisingManagement.Domain.UnitTests.Specifications
{
	public class ProductSpecificationTests
	{
		//TODO: use moq
		public List<Product> GetProductCollection()
		{
			return new List<Product>()
			{
				Product.Create(1, "Sample Product 1", "Description 1", 10 ),
				Product.Create(2, "Sample Product 2", "Description 2", 20 ),
				Product.Create(3, "Sample Product 3", "Description 3", 30,1),
				Product.Create(4, "Sample Product 4", "Description 4", 40,1),
				Product.Create(5, "Sample Product 5", "Description 5", 50),
				Product.Create(6, "Sample Product 6", "Description 6", 60),
				Product.Create(7, "keyword tester", "Description 7", 10),
				Product.Create(8, "Sample Product 8", "keyword tester", 10),


			};
		}

		[Fact]
		public void ReturnsWithCategoryCount()
		{
			var spec = new HasCategorySpecification(null);

			var result = GetProductCollection()
				.AsQueryable()
				.Where(spec.Criteria)
				.Count();

			Assert.Equal(2, result);
		}

		[Fact]
		public void ReturnsWithCategory()
		{
			var spec = new HasCategorySpecification(null);

			var result = GetProductCollection()
				.AsQueryable()
				.Where(spec.Criteria)
				.FirstOrDefault();
			Assert.NotNull(result);
			Assert.Equal(3, result.Id);
		}

		[Fact]
		public void ReturnsStockLowerThanCount()
		{
			var spec = new StockLowerThanSpecification(40);

			var result = GetProductCollection()
				.AsQueryable()
				.Where(spec.Criteria)
				.Count();

			Assert.Equal(5, result);
		}

		[Fact]
		public void ReturnsStockLowerThan()
		{
			var spec = new StockLowerThanSpecification(50);

			var result = GetProductCollection()
				.AsQueryable()
				.FirstOrDefault(spec.Criteria);
			Assert.NotNull(result);
			Assert.Equal(1, result.Id);
		}


		[Fact]
		public void ReturnsStockHigherThanCount()
		{
			var spec = new StockHigherThanSpecification(40);

			var result = GetProductCollection()
				.AsQueryable()
				.Where(spec.Criteria)
				.Count();

			Assert.Equal(2, result);
		}

		[Fact]
		public void ReturnsStockHigherThan()
		{
			var spec = new StockHigherThanSpecification(50);

			var result = GetProductCollection()
				.AsQueryable()
				.FirstOrDefault(spec.Criteria);
			Assert.NotNull(result);
			Assert.Equal(6, result.Id);
		}

		[Fact]
		public void ReturnsKeywordCount()
		{
			var spec = new HasSearchKeywordSpecification("keyword");

			var result = GetProductCollection()
				.AsQueryable()
				.Where(spec.Criteria)
				.Count();

			Assert.Equal(2, result);
		}

		[Fact]
		public void ReturnsKeywordThan()
		{
			var spec = new HasSearchKeywordSpecification("1");

			var result = GetProductCollection()
				.AsQueryable()
				.FirstOrDefault(spec.Criteria);
			Assert.NotNull(result);
			Assert.Equal(1, result.Id);
		}


	}
}

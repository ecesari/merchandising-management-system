using System.Collections.Generic;
using System.Linq;
using Application.Common.Mappers;
using Application.Product.Commands;
using Application.Product.Queries.GetProducts;
using Application.Product.Queries.SearchProducts;
using AutoMapper;
using Xunit;

namespace Application.UnitTests.Common.Mapper
{
	public class MapperTests
	{
		private readonly IMapper _mapper;

		public MapperTests()
		{
			IConfigurationProvider configuration = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapperConfig());
			});
			_mapper = configuration.CreateMapper();
		}


		[Theory]
		[InlineData( "Sample Title", "Sample Description", 50, 3 )]
		[InlineData( "Title", "Description", 0, 30 )]
		public void CreateCommandMappings(string title, string description, int stockQuantity, int categoryId)
		{
			var command = new CreateProductCommand
			{
				CategoryId = categoryId,
				Description = description,
				StockQuantity = stockQuantity,
				Title = title
			};
			var product = _mapper.Map<Domain.Entities.Product>(command);
			Assert.NotNull(product);
			Assert.Equal(title,product.Title);
			Assert.Equal(description,product.Description);
			Assert.Equal(stockQuantity,product.StockQuantity);
			Assert.Equal(categoryId,product.CategoryId);

		}

		[Theory]
		[InlineData("Sample Title", "Sample Description", 50, 3)]
		[InlineData("Title", "Description", 0, 30)]
		public void UpdateCommandMappings(string title, string description, int stockQuantity, int categoryId)
		{
			var command = new UpdateProductCommand
			{
				CategoryId = categoryId,
				Description = description,
				StockQuantity = stockQuantity,
				Title = title
			};
			var product = _mapper.Map<Domain.Entities.Product>(command);
			Assert.NotNull(product);
			Assert.Equal(title, product.Title);
			Assert.Equal(description, product.Description);
			Assert.Equal(stockQuantity, product.StockQuantity);
			Assert.Equal(categoryId, product.CategoryId);

		}


		[Theory]
		[InlineData(1,"Sample Title", "Sample Description", 50, 3)]
		[InlineData(2,"Title", "Description", 0, 30)]
		public void SearchProductQueryMappings(int id,string title, string description, int stockQuantity, int categoryId)
		{
			var product = Domain.Entities.Product.Create(id, title, description, stockQuantity, categoryId);
			var product2 = Domain.Entities.Product.Create(id, title, description, stockQuantity, categoryId);
			var productList = new List<Domain.Entities.Product> {product, product2};

			var viewModel = _mapper.Map<SearchProductsViewModel>(productList);

			Assert.NotNull(viewModel);
			Assert.NotEmpty(viewModel.Products);
			Assert.NotNull(viewModel.Products.FirstOrDefault());
			Assert.Equal(2, viewModel.Products.Count);
			Assert.Equal(id,viewModel.Products.FirstOrDefault().Id);
			Assert.Equal(title,viewModel.Products.FirstOrDefault().Title);
			Assert.Equal(description,viewModel.Products.FirstOrDefault().Description);
			Assert.Equal(stockQuantity,viewModel.Products.FirstOrDefault().StockQuantity);
			Assert.Equal(categoryId,viewModel.Products.FirstOrDefault().CategoryId);

		}

		[Theory]
		[InlineData(1, "Sample Title", "Sample Description", 50)]
		[InlineData(2, "Title", "Description", 0)]
		public void GetProductsQueryMappings(int id, string title, string description, int stockQuantity)
		{
			var product = Domain.Entities.Product.Create(id, title, description, stockQuantity);
			var product2 = Domain.Entities.Product.Create(id, title, description, stockQuantity);
			var productList = new List<Domain.Entities.Product> { product, product2 };

			var viewModel = _mapper.Map<GetProductsViewModel>(productList);

			Assert.NotNull(viewModel);
			Assert.NotEmpty(viewModel.Products);
			Assert.NotNull(viewModel.Products.FirstOrDefault());
			Assert.Equal(2, viewModel.Products.Count);
			Assert.Equal(id, viewModel.Products.FirstOrDefault().Id);
			Assert.Equal(title, viewModel.Products.FirstOrDefault().Title);
			Assert.Equal(description, viewModel.Products.FirstOrDefault().Description);
			Assert.Equal(stockQuantity, viewModel.Products.FirstOrDefault().StockQuantity);

		}
	}
}

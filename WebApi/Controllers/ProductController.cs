using System.Threading.Tasks;
using MediatR;
using MerchandisingManagement.Application.Product.Commands;
using MerchandisingManagement.Application.Product.Queries.GetProducts;
using MerchandisingManagement.Application.Product.Queries.GetProductsByStockRange;
using MerchandisingManagement.Application.Product.Queries.SearchProducts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchandisingManagement.WebApi.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class ProductController : WebApiControllerBase
	{
		private readonly IMediator _mediator;

		public ProductController( IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Get all products, unfiltered
		/// </summary>
		[HttpGet]
		public async Task<ActionResult<GetProductsViewModel>> GetProducts([FromQuery] GetProductsQuery query)
		{
			return await _mediator.Send(query);
		}

		/// <param name="query">Products list</param>

		[HttpGet("GetByKeyword")]
		public async Task<ActionResult<SearchProductsViewModel>> SearchProducts([FromQuery] SearchProductsQuery query)
		{
			return await _mediator.Send(query);
		}

		/// <param name="query">Products list</param>
		[HttpGet("GetByStock")]
		public async Task<ActionResult<ProductByStockRangeViewModel>> GetProductsInStockRange([FromQuery] GetProductsByStockRangeQuery query)
		{
			return await _mediator.Send(query);
		}


		[HttpPost]
		[Route("~/api/CreateProduct")]
		public async Task<ActionResult<int>> CreateProduct(CreateProductCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpPut]
		[Route("~/api/UpdateProduct")]

		public async Task<ActionResult> Update(UpdateProductCommand command)
		{
			await _mediator.Send(command);

			return new NoContentResult();
		}

		[HttpDelete]
		[Route("~/api/DeleteProduct")]
		public async Task<ActionResult> Delete(DeleteProductCommand command)
		{
			await _mediator.Send(command);

			return new NoContentResult();
		}
	}
}

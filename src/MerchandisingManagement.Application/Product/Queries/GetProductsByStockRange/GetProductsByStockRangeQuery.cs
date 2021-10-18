using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Domain.Specifications.Product;

namespace MerchandisingManagement.Application.Product.Queries.GetProductsByStockRange
{
	public class GetProductsByStockRangeQuery : IRequest<ProductByStockRangeViewModel>
	{
		public int MinValue { get; set; }
		public int MaxValue { get; set; }
	}

	public class GetProductsByStockRangeQueryHandler : IRequestHandler<GetProductsByStockRangeQuery, ProductByStockRangeViewModel>
	{
		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public GetProductsByStockRangeQueryHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<ProductByStockRangeViewModel> Handle(GetProductsByStockRangeQuery request, CancellationToken cancellationToken)
		{
			var specification = new StockInRangeSpecification(request.MinValue, request.MaxValue);
			var entities = await _productRep.GetAsync(specification);
			var viewModel = _mapper.Map<ProductByStockRangeViewModel>(entities);
			return await Task.FromResult(viewModel);
		}
	}
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Domain.Specifications.Product;

namespace MerchandisingManagement.Application.Product.Queries.GetProducts
{
	public class GetProductsQuery : IRequest<GetProductsViewModel>
	{
	}

	public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsQuery, GetProductsViewModel>
	{
		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public GetProductsWithPaginationQueryHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<GetProductsViewModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
		{
			var specification = new HasStockOfCategorySpecification(null);
			var entities = await _productRep.GetAsync(specification);
			var viewModel = _mapper.Map<GetProductsViewModel>(entities);
			return await Task.FromResult(viewModel);
		}
	}
}

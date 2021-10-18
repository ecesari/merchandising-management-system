using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Domain.Specifications.Product;

namespace MerchandisingManagement.Application.Product.Queries.SearchProducts
{
	public class SearchProductsQuery : IRequest<SearchProductsViewModel>
	{
		public string SearchQuery { get; set; }
	}

	public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductsViewModel>
	{
		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public SearchProductsQueryHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<SearchProductsViewModel> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
		{
			var keywordSpecification = new HasSearchKeywordSpecification(request.SearchQuery);
			var specification = new HasStockOfCategorySpecification(keywordSpecification.Criteria);
			var entities = await _productRep.GetAsync(specification);
			var viewModel = _mapper.Map<SearchProductsViewModel>(entities);
			return await Task.FromResult(viewModel);
		}
	}
}

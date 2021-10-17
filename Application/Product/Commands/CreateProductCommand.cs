using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Product.Commands
{
	public class CreateProductCommand : IRequest<int>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public int CategoryId { get; set; }
	}

	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
	{

		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public CreateProductCommandHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<Domain.Entities.Product>(request);
			if (entity == null)
			{
				throw new ApplicationException("There was an error with the mapper!");
			}
			var newEntity = await _productRep.AddAsync(entity);
			return newEntity.Id;
		}
	}
}


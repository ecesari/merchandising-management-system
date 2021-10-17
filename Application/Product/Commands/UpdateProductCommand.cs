using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchandisingManagement.Domain.Repositories;

namespace MerchandisingManagement.Application.Product.Commands
{
	public class UpdateProductCommand : IRequest
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public int CategoryId { get; set; }
	}

	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{

		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public UpdateProductCommandHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<Domain.Entities.Product>(request);
			if (entity == null)
				throw new ApplicationException("There was an error with the mapper!");
			
			await _productRep.UpdateAsync(entity);
			return Unit.Value;
		}
	}
}


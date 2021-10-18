using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchandisingManagement.Domain.Repositories;

namespace MerchandisingManagement.Application.Product.Commands
{
	public class DeleteProductCommand : IRequest
	{
		public int Id { get; set; }
	}

	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
	{

		private readonly IProductRepository _productRep;
		private readonly IMapper _mapper;

		public DeleteProductCommandHandler(IProductRepository productRep, IMapper mapper)
		{
			_productRep = productRep;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var entity = await _productRep.GetByIdAsync(request.Id);
			if (entity == null)
			{
				throw new ApplicationException("No entity was found!");
			}

			await _productRep.DeleteAsync(entity);
			return Unit.Value;
		}
	}
}


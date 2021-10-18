using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repositories;

namespace Application.Services
{
	public interface IProductService
	{

	}
	public class ProductService
	{

		private readonly IProductRepository _productRep;
		public ProductService(IProductRepository productRep)
		{
			_productRep = productRep;
		}

	}
}

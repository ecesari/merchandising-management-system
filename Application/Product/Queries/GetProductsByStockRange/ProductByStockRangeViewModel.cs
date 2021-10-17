using System.Collections.Generic;
using MerchandisingManagement.Application.Product.Queries.SearchProducts;

namespace MerchandisingManagement.Application.Product.Queries.GetProductsByStockRange
{
	public class ProductByStockRangeViewModel
	{
		public IList<ProductSearchDto> Products { get; set; }
	}
}

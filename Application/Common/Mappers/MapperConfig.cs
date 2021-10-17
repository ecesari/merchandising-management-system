using System.Collections.Generic;
using AutoMapper;
using MerchandisingManagement.Application.Product.Commands;
using MerchandisingManagement.Application.Product.Queries.GetProducts;
using MerchandisingManagement.Application.Product.Queries.SearchProducts;

namespace MerchandisingManagement.Application.Common.Mappers
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			//Product Command Mapper
			CreateMap<CreateProductCommand, Domain.Entities.Product>();
			CreateMap<UpdateProductCommand, Domain.Entities.Product>();

			//Product Query Mapper
			CreateMap<Domain.Entities.Product, ProductSearchDto>();
			CreateMap<IReadOnlyList<Domain.Entities.Product>, SearchProductsViewModel>()
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));

			CreateMap<Domain.Entities.Product, GetProductsDto>();
			CreateMap<IReadOnlyList<Domain.Entities.Product>, GetProductsViewModel>()
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));
		}
	}
}

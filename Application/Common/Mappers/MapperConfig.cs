using System.Collections.Generic;
using Application.Product.Commands;
using Application.Product.Queries.GetProducts;
using Application.Product.Queries.SearchProducts;
using AutoMapper;

namespace Application.Common.Mappers
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

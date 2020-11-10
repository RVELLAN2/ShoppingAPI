using AutoMapper;
using ShoppingAPI.Data;
using ShoppingAPI.Models.Products;
using ShoppingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile(PricingConfiguration config)
        {
            CreateMap<Product, ProductSummaryItem>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice * config.MarkUp));

            CreateMap<Product, GetProductDetailsResponse>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice * config.MarkUp));

            CreateMap<PostProductRequest, Product>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(s => s.UnitPrice.Value))
                .ForMember(dest => dest.InInventory, opt => opt.MapFrom(_ => true));
        }
    }
}

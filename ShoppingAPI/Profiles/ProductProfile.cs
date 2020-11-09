using AutoMapper;
using ShoppingAPI.Data;
using ShoppingAPI.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSummaryItem>();

            CreateMap<Product, GetProductDetailsResponse>();

            CreateMap<PostProductRequest, Product>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(s => s.UnitPrice.Value))
                .ForMember(dest => dest.InInventory, opt => opt.MapFrom(_ => true));
        }
    }
}

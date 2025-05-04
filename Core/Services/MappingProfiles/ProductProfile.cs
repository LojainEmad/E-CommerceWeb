using AutoMapper;
using Domain.Models.Products;
using Microsoft.Extensions.Options;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class ProductProfile:Profile

    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(Dist => Dist.BrandName, options => options.MapFrom(src => src.Brand.Name))
                .ForMember(Dist => Dist.TypeName, options => options.MapFrom(src => src.Type.Name))
                .ForMember(Dist => Dist.PictureUrl, options => options.MapFrom<ProductResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }

    }
}

using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Products;
using Services.Specifications;
using Shared;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices(IUnitOfWork unitOfWork ,IMapper mapper) : IProductServices
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Repository =unitOfWork.GetRepository<ProductBrand , int>();
            var Brands =await _Repository.GetAllAsync();
            var MapperBrands = mapper.Map<IEnumerable<ProductBrand>,IEnumerable <BrandDto>>(Brands);
            return MapperBrands;
        }

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams productQuery)
        {
           
            var _Repository = unitOfWork.GetRepository<Product, int>();
            var Spec = new ProductWithBrandAndTypeSpecification(productQuery);  //2 includes without Where
            var Products = await _Repository.GetAllAsync(Spec);
            var MapperProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);


            var CountedProducts = Products.Count();
            return new PaginatedResult<ProductDto>(productQuery.PageIndex, CountedProducts , 0 , MapperProducts);

        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductType, int>();
            var Types = await _Repository.GetAllAsync();
            var MapperTypes = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return MapperTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Spec = new ProductWithBrandAndTypeSpecification(id); 
            var Product = await unitOfWork.GetRepository<Product,int>().GetByIdAsync(Spec);
            return mapper.Map<Product,ProductDto>(Product);
        }
    }
}

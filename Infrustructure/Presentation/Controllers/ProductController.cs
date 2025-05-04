using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServicesManager servicesManager):ControllerBase
    {
        //GetAllProducts
        //Get BaseUrL/api/Products
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery]ProductQueryParams productQuery)
        {
            var Products = await servicesManager.ProductServices.GetAllProductsAsync(productQuery);

            return Ok(Products);
        }

        //GetAllBrands
        //Get BaseUrL/api/Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var Brands = await servicesManager.ProductServices.GetAllBrandsAsync();

            return Ok(Brands);
        }

        //GetAllTypes
        //Get BaseUrL/api/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await servicesManager.ProductServices.GetAllTypesAsync();

            return Ok(Types);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
           var Product =await servicesManager.ProductServices.GetProductByIdAsync(id);
            return Ok(Product);
        }
    }
}

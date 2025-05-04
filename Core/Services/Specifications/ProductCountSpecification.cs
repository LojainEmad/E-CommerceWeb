using Domain.Models.Products;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductCountSpecification:BaseSpecifications<Product,int>
    {


        public ProductCountSpecification(ProductQueryParams productQuery)
          : base(P => (!productQuery.BrandId.HasValue || P.BrandId == productQuery.BrandId)
          && (!productQuery.TypeId.HasValue || P.TypeId == productQuery.TypeId)
          && (string.IsNullOrEmpty(productQuery.SearchValue) || P.Name.ToLower().Contains(productQuery.SearchValue.ToLower())))

        {

        }


    }
}

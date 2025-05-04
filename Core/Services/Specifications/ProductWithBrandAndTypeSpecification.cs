using Domain.Models.Products;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecification:BaseSpecifications<Product , int>
    {
        //where(true && true)
        public ProductWithBrandAndTypeSpecification(ProductQueryParams productQuery)
            :base(P=>(!productQuery.BrandId.HasValue || P.BrandId== productQuery.BrandId) 
                  && (!productQuery.TypeId.HasValue ||P.TypeId == productQuery.TypeId)
                  && (string.IsNullOrEmpty(productQuery.SearchValue)||P.Name.ToLower().Contains(productQuery.SearchValue.ToLower()) ))
                  
        {
            AddInclude(P => P.Brand);
            AddInclude(P=>P.Type);

            switch (productQuery.SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(P => P.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(P => P.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(P => P.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(P => P.Price);
                    break;
                default:
                    break;
            }

        }

        public ProductWithBrandAndTypeSpecification(int id):base(P=>P.Id==id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Type);
        }

    }
}

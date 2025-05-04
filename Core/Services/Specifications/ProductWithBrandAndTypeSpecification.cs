using Domain.Models.Products;
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
        public ProductWithBrandAndTypeSpecification(int? brandId, int? TypeId)
            :base(P=>(!brandId.HasValue || P.BrandId==brandId) 
                  && (!TypeId.HasValue ||P.TypeId ==TypeId))
        {
            AddInclude(P => P.Brand);
            AddInclude(P=>P.Type);

        }

        public ProductWithBrandAndTypeSpecification(int id):base(P=>P.Id==id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Type);
        }

    }
}

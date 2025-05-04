using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configrations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.Brand)
                .WithMany(B => B.Products)
                .HasForeignKey(P => P.BrandId);

            builder.HasOne(P => P.Type)
              .WithMany(B => B.Products)
              .HasForeignKey(P => P.TypeId);

            builder.Property(P => P.Price)
                .HasPrecision(10, 3); // precision: 10 digits total, scale: 3 after the decimal

        }
    }
}

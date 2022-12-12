using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.data.Configurations
{
    public class ProductPropertiesConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(x=>x.prodPicture).IsRequired();

            builder.Property(x=>x.prodDescription).IsRequired().HasMaxLength(200);

            builder.Property(x=>x.prodName).IsRequired().HasMaxLength(15);

            builder.Property(x=>x.prodPrice).HasColumnType("decimal(10,2)");

            builder.HasOne(x=>x.productBrand).WithMany().
            HasForeignKey(x=>x.productBrandId);

            builder.HasOne(x=>x.productType).WithMany().
            HasForeignKey(x=>x.productTypeId);
        }
    }
}
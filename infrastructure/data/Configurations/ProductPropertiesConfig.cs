using core.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductPropertiesConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p => p.id).IsRequired();
            builder.Property(p => p.prodName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.prodDescription).IsRequired();
            builder.Property(p => p.prodPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.prodPicture).IsRequired();
            builder.HasOne(p => p.productBrand).WithMany()
                .HasForeignKey(p => p.productBrandId);
            builder.HasOne(p => p.productType).WithMany()
                .HasForeignKey(p => p.productTypeId);
        }
    }
}
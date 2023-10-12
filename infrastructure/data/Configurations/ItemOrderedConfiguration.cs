using core.Entities.Oders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.data.Configurations
{
    public class ItemOrderedConfiguration : IEntityTypeConfiguration<ItemOrdered>
    {
        public void Configure(EntityTypeBuilder<ItemOrdered> builder)
        {
            builder.OwnsOne(x => x.productOrdered , y=>{y.WithOwner();
           });

            builder.Property(x => x.itemPrice).HasColumnType("decimal(18,2)");
           
        }
    }
}
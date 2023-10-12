using core.Entities.Oders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.data.Configurations
{
    public class AdminOrderConfiguration : IEntityTypeConfiguration<AdminOrder>
    {
         public void Configure(EntityTypeBuilder<AdminOrder> builder)
        {
           builder.OwnsOne(x => x.address , y=>{y.WithOwner();
           });

           builder.Navigation(x => x.address ).IsRequired();

           builder.Property(x => x.orderStatus )
           .HasConversion(y=>y.ToString(),
           y=>(OrderStatus)Enum.Parse(typeof(OrderStatus),y));
           
            builder.HasMany(x => x.itemOrdered)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
           }
        }
    }

using Microsoft.EntityFrameworkCore;
using core.Controllers;
using System.Reflection;
using core.Entities.Oders;
using core.Entities.Adverts;

namespace infrastructure.data
{
    public class productContext : DbContext
    {
        public productContext(DbContextOptions<productContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ItemOrdered> ItemOrdered { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Adverts> Adverts { get; set; }
         public DbSet<AdminOrder> AdminOrder { get; set; }
        //This code creates configuration of our entities models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
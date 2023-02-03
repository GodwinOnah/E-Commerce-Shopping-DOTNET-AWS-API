using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using core.Controllers;
using System.Reflection;

namespace infrastructure.data
{
    public class storeProducts : DbContext
    {
        public storeProducts(DbContextOptions<storeProducts> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductBrand> ProductBrand { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        //This code creates configuration of our entities models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
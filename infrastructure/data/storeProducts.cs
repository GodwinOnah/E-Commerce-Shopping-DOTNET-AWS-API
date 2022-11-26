using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using core.Controllers;

namespace infrastructure.data
{
    public class storeProducts : DbContext
    {
        public storeProducts(DbContextOptions<storeProducts> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
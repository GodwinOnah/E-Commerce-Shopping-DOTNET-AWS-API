using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API.data
{
    public class storeProducts : DbContext
    {
        public storeProducts(DbContextOptions<storeProducts> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
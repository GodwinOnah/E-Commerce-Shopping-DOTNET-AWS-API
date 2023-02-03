using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace core.Entities.Identity
{
    public class MyAppIdentityDbContext : IdentityDbContext<User>
    {
        public MyAppIdentityDbContext(DbContextOptions<MyAppIdentityDbContext> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }

    
}
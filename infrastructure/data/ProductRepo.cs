using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Controllers;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data
{
    public class ProductRepo : IproductsInt
    
    {

         public storeProducts Products { get; }
        public ProductRepo(storeProducts products)
        {
            this.Products = products;
        }

        public async Task<IReadOnlyList<Products>> GetProductsAdsync()
        {
            var productsList=await Products.Products.ToListAsync();

            return productsList;
        }

        public async Task<Products> GetProductsByIDAdsync(int id)
        {
             var product=await Products.Products.FindAsync(id);


            return product;
        }
    }
}
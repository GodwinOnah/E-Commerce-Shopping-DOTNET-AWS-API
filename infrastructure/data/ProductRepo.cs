using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Controllers;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data
{
    public class ProductRepo : IProductInterface

    {
        private readonly storeProducts _products;

      
        public ProductRepo(storeProducts products)
        {
            _products = products;
        }

        public async Task<IReadOnlyList<Products>> GetProductsAdsync()
        {
           return await _products.Products.ToListAsync();

            
        }

        public async Task<Products> GetProductsByIDAdsync(int id)
        {
              return await _products.Products.FindAsync(id);
   
        }
    }
}
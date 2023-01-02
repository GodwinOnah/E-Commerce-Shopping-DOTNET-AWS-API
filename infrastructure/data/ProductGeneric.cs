using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data.ProductsData
{
    public class ProductGeneric<T> : IgenericProductInterface<T> where T : ProductEntities
    {

         private readonly storeProducts _context;
        public ProductGeneric(storeProducts context)
        {
            _context = context;
        }

       public async Task<T> GetProductsByIdAdsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        
        }
        

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            
            return await _context.Set<T>().ToListAsync();

            
        }

        public async Task<T> GetProductsWithSpecification(ISpecificationProducts<T> specification)
        {
            return await ApplyProductSpecs(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(ISpecificationProducts<T> specification)
        {
            return await ApplyProductSpecs(specification).ToListAsync();
        }

        private IQueryable<T> ApplyProductSpecs(ISpecificationProducts<T> specification)
        {

            return ProductSpecictaionEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),specification);
        }
    }
}
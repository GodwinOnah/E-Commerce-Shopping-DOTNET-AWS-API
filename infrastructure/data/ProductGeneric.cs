using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data.ProductsData
{
    public class ProductGeneric<T> : IgenericInterfaceRepository<T> where T : ProductEntities
    {

         private readonly productContext _context;
        public ProductGeneric(productContext context)
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

        public async Task<int> CountPage(ISpecificationProducts<T> specification)
        {
            return await ApplyProductSpecs(specification).CountAsync();
        }

        void IgenericInterfaceRepository<T>.Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        void IgenericInterfaceRepository<T>.Update(T entity)
        {
             _context.Set<T>().Attach(entity);
             _context.Entry(entity).State = EntityState.Modified;
        }

        void IgenericInterfaceRepository<T>.Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }
    }
}
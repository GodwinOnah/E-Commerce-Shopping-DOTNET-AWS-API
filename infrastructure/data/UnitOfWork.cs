using System.Collections;
using core.Controllers;
using core.Entities;
using core.Entities.Adverts;
using core.Entities.Oders;
using core.Interfaces;
using infrastructure.data.ProductsData;

namespace infrastructure.data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly productContext _storeProducts;
        public Hashtable _repository;
        public UnitOfWork(productContext storeProducts)
        {
            _storeProducts = storeProducts;
        }

        public async Task<int> complete()
        {
            return await  _storeProducts.SaveChangesAsync();
        }

         public async Task delete(int id)
        {
            var product = new Products()
            {
                id = id
             };
             _storeProducts.Remove(product);
           
           
        }


        public void Dispose()
        {
           _storeProducts.Dispose();
           
        }


        public IgenericInterfaceRepository<TEntity> Repository<TEntity>() 
        where TEntity : ProductEntities
        {
            if(_repository == null) 
                _repository = new Hashtable();

            var type = typeof(TEntity).Name;

            if(!_repository.Contains(type)){
                var repositoryType = typeof(ProductGeneric<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)),
                     _storeProducts);

                 _repository.Add(type,repositoryInstance);
            }
            return (IgenericInterfaceRepository<TEntity>)  _repository[type];
        }

        public async Task deleteAdminOrder(int id)
        {
            var adminOrder = new AdminOrder()
            {
                id = id
             };
             _storeProducts.Remove(adminOrder);
        }

        public async Task deleteAdverts(int id)
        {
            var advert = new Adverts()
            {
                id = id
             };
             _storeProducts.Remove(advert);
        }

         public async Task deleteProductBrand(int id)
        {
            var productBrand = new ProductBrand()
            {
                id = id
             };
             _storeProducts.Remove(productBrand);
        }

         public async Task deleteProductType(int id)
        {
            var productType = new ProductType()
            {
                id = id
             };
             _storeProducts.Remove(productType);
        }

         public async Task deleteDelivery(int id)
        {
            var delivery = new Delivery()
            {
                id = id
             };
             _storeProducts.Remove(delivery);
        }

        


         
    }
}
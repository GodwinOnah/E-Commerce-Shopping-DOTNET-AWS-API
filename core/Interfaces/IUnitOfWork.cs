using core.Entities;

namespace core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IgenericInterfaceRepository<TEntity> Repository<TEntity>() where TEntity : ProductEntities;

        Task<int> complete();
         Task delete(int id);
          Task deleteAdminOrder(int id);
          Task deleteProductBrand(int id);
         Task deleteProductType(int id);
         Task deleteAdverts(int id); 
         Task deleteDelivery(int id);
    }
}
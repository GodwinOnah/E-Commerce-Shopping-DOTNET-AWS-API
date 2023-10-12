using core.Controllers;

namespace core.Interfaces
{
    public interface IProductInterface
    {
         Task<IReadOnlyList<Products>> GetProductsAdsync();
         Task<Products> GetProductsByIDAdsync(int id);
         
    }
}
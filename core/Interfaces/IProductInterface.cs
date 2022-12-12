using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Controllers;

namespace core.Interfaces
{
    public interface IProductInterface
    {
         Task<IReadOnlyList<Products>> GetProductsAdsync();
         Task<Products> GetProductsByIDAdsync(int id);
    }
}
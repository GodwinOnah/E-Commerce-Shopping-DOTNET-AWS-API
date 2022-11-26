using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Controllers;

namespace infrastructure
{
    public interface IproductsInt
    {
        Task<Products> GetProductsByIDAdsync(int id);
        Task<IReadOnlyList<Products>> GetProductsAdsync();
    }
}
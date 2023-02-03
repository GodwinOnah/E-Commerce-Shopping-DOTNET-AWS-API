using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IBasket
    {
        Task<Basket> GetBasketAsync(string Id);

        Task<Basket> UpdateBasketAsync(Basket basket);

        Task<bool> DeleteBasketAsync(string Id);
    }
}
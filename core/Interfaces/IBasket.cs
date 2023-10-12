namespace core.Interfaces
{
    public interface IBasket
    {
        Task<Basket> GetBasketAsync(string Id);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task<bool> DeleteBasketAsync(string Id);
    }
}
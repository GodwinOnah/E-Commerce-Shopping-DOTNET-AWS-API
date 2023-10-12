using core.Entities.Oders;

namespace core.Interfaces
{
    public interface IOrders
    {
        Task<Order> CreateOrdersAsync(string email, string basketId, int deliveryId, ShippingAddress address);
        Task<IReadOnlyList<Order>> GetOrdersAsync(string email);
        Task<Order> GetOrdersByIdAsync(int id, string email);
        Task<IReadOnlyList<Delivery>> GetDeliverysAsync();
        Task<bool> AddDeliverysAsync(Delivery delivery);
        Task<bool> DeleteDeliverysAsync(int id);
        Task<bool> UpdateOrdersByIdAsync(OrderConfirmDetails details);
    }
}
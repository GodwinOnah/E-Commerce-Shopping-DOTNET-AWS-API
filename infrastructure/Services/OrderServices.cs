using core.Controllers;
using core.Entities.Oders;
using core.Interfaces;

using core.Specifications;

namespace infrastructure.Services
{
    public class OrderServices : IOrders
    {
        
        private readonly IBasket _basketRepo;
        private readonly IUnitOfWork _iUnitOfWork;
        public OrderServices(IUnitOfWork iUnitOfWork,
         IBasket basketRepo)
        {
            _iUnitOfWork = iUnitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrdersAsync(string email, string basketId, int deliveryId, ShippingAddress address)
        {        
           var basket = await _basketRepo.GetBasketAsync(basketId);
           if(basket==null)return null;
            var items = new List<ItemOrdered>();
           foreach (var item in basket.Items){    
            var productItem = await _iUnitOfWork.Repository<Products>()
                        .GetProductsByIdAdsync(item.id);
            var productOrdered = new ProductOrdered(productItem.id,
                        productItem.prodName,productItem.prodPicture);
            var itemOrdered = new ItemOrdered(productOrdered,productItem
                        .prodPrice,item.quantity);                    
            items.Add(itemOrdered);   
           }
           var delivery = await _iUnitOfWork.Repository<Delivery>().GetProductsByIdAdsync(deliveryId);
           
            // Console.WriteLine("\n\n\n\n\n\n\n\n"+delivery.delDescription+"\n\n\n\n\n\n\n\n");
            var result = await _iUnitOfWork.complete();
           var subTotal = items.Sum(item => item.itemPrice*item.quantity);
           var specification = new OrderPaymentSpecification(basket.paymentIntentId);
            var order = await _iUnitOfWork.Repository<Order>().GetProductsWithSpecification(specification);
           
            if(order!=null){
                order.address = address;
                order.delivery = delivery;
                order.subTotal = subTotal;
                _iUnitOfWork.Repository<Order>().Update(order);

            }
            else{
                 order = new Order(items,email,delivery,address,basket.paymentIntentId,subTotal);
                 _iUnitOfWork.Repository<Order>().Add(order);
          

            }
           
            var results = await _iUnitOfWork.complete();

           if(results <= 0) return null;
           return order;
        }

        public async Task<IReadOnlyList<Delivery>> GetDeliverysAsync()
        {
            return await _iUnitOfWork.Repository<Delivery>()
            .ListAllAsync();
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync(string email)
        {
            var specification = new OrderWithItemsAndSpecification(email);
            return await _iUnitOfWork.Repository<Order>()
            .ListAllAsync(specification);
        }
        public async Task<Order> GetOrdersByIdAsync(int id, string email)
        {
            var specification = new OrderWithItemsAndSpecification(id,email);
            return await _iUnitOfWork.Repository<Order>()
            .GetProductsWithSpecification(specification);
        }

        public async Task<bool> UpdateOrdersByIdAsync(OrderConfirmDetails details)
        {
            // Console.WriteLine("\n\n\n\n\n\n\n\n"+details.Email+"\n\n\n\n\n\n\n\n");
            //  Console.WriteLine("\n\n\n\n\n\n\n\n"+details.id+"\n\n\n\n\n\n\n\n");
            var specification = new OrderWithItemsAndSpecification(details.id,details.Email);
            var order = await  _iUnitOfWork.Repository<Order>()
            .GetProductsWithSpecification(specification);

            if(order != null){
                order.confirmation = "confirmed";
                _iUnitOfWork.Repository<Order>().Update(order);
              await  _iUnitOfWork.complete();

            }
            return true;
        }

       public async Task<bool> AddDeliverysAsync(Delivery delivery)
        {      
           _iUnitOfWork.Repository<Delivery>().Add(delivery);
           await _iUnitOfWork.complete();
           return true;
        }

       public async Task<bool> DeleteDeliverysAsync(int id)
        {
            await    _iUnitOfWork.deleteDelivery(id);
            await _iUnitOfWork.complete();
             return true;
        }
    }
}
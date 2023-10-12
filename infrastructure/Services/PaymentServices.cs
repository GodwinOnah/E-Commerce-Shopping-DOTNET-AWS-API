using core.Controllers;
using core.Entities.Interfaces;
using core.Entities.Oders;
using core.Interfaces;
using core.Specifications;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace core
{
    public class PaymentServices : IPaymentService
    {
        private readonly IBasket _basket;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public PaymentServices(IBasket basket,
        IUnitOfWork unitOfWork,
        IConfiguration config)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _basket = basket;
        }

        public async Task<Basket> CreateOrUpdateIntent(string basketId)
        {
            StripeConfiguration.ApiKey= _config["StripeSettings:SecretKey"];
            var basket = await _basket.GetBasketAsync(basketId);
            var DelPrice = 0;
            Console.WriteLine(basket.Items);

            if(basket.deliveryId.HasValue){
                var delivery = await _unitOfWork.Repository<Delivery>()
                .GetProductsByIdAdsync((int)basket.deliveryId);
                DelPrice = (int)delivery.delPrice;
            }

            foreach(var item in basket.Items){
                   var productItem = await _unitOfWork.Repository<Products>()
                   .GetProductsByIdAdsync(item.id);
                   if(item.prodPrice != productItem.prodPrice){
                        item.prodPrice = productItem.prodPrice;
                   }
            }
                    var service = new PaymentIntentService();
                    PaymentIntent intent;

                    if(string.IsNullOrEmpty(basket.paymentIntentId)){
                        var options = new PaymentIntentCreateOptions{
                            Amount = (long)basket.Items
                            .Sum(i=> i.quantity * (i.prodPrice*100))+(long)DelPrice,
                            Currency = "gbp",
                            PaymentMethodTypes = new List<string> {"card"}
                        };
                        intent = await service.CreateAsync(options);
                        basket.paymentIntentId = intent.Id;
                        basket.clientSecret = intent.ClientSecret;
                      
            }

                        else{
                            var options = new PaymentIntentUpdateOptions{
                            Amount = (long)basket.Items
                            .Sum(i=> i.quantity * (i.prodPrice*100))+(long)DelPrice,
                            };
                            await service.UpdateAsync(basket.paymentIntentId,options);
                        }
                        await _basket.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var specification = new OrderPaymentSpecification(paymentIntentId);
            var order =  await _unitOfWork.Repository<Order>().GetProductsWithSpecification(specification);
            if(order == null) return null;
            order.orderStatus = OrderStatus.PaymentFailed;
            await _unitOfWork.complete();
            return order;
        }   

         public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n I LOVE YOU 1 \n\n\n\n\n\n\n\n");
            var specification = new OrderPaymentSpecification(paymentIntentId);
            var order =  await _unitOfWork.Repository<Order>().GetProductsWithSpecification(specification);
            if(order == null) return null;
            order.orderStatus = OrderStatus.PaymentReceived;
            // Console.WriteLine("\n\n\n\n\n\n\n\n"+order.id+"\n\n\n\n\n\n\n\n");
             Console.WriteLine("\n\n\n\n\n\n\n\n I LOVE YOU 2 \n\n\n\n\n\n\n\n");
            // Console.WriteLine("\n\n\n\n\n\n\n\n"+order.orderDate+"\n\n\n\n\n\n\n\n");
            var adminOrder = new AdminOrder(order.id,order.itemOrdered,order.Email,order.address,order.delivery);
            _unitOfWork.Repository<AdminOrder>().Add(adminOrder); // saving to admin order table
            await _unitOfWork.complete();
            return order;
        }
     
    }
}
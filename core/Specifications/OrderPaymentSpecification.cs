using core.Entities.Oders;
using infrastructure.data;

namespace core.Specifications
{
    public class OrderPaymentSpecification : Specification<Order>
    {
        public OrderPaymentSpecification(string paymentIntentId) :
         base(o => o.paymentIntentId == paymentIntentId)
        {
             AddProdInclude(o=>o.delivery);
             AddProdInclude(o=>o.itemOrdered);
        }
    }
}
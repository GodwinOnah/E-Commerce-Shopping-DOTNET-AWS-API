using infrastructure.data;

namespace core.Entities.Oders
{
    public class OrderWithItemsAndSpecification : Specification<Order>
    {
        public OrderWithItemsAndSpecification(string email) 
        : base(o=>o.Email==email)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.delivery);
            AddOrderByDescending(o=>o.orderDate);
            AddProdInclude(o=>o.address);
        }

        public OrderWithItemsAndSpecification(int id, string email) 
        : base(o=>o.id==id && o.Email==email)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.delivery);
            AddProdInclude(o=>o.address);
        }

        public OrderWithItemsAndSpecification(int id) 
        : base(o=>o.id==id)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.delivery);
            AddProdInclude(o=>o.address);
        }

         public OrderWithItemsAndSpecification(OrderStatus orderStatus) 
        : base(o=>o.orderStatus==orderStatus)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.address);
            AddOrderByDescending(o=>o.orderDate);
        }
    }
}
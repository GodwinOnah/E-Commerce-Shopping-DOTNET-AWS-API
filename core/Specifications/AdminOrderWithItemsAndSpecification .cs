using infrastructure.data;

namespace core.Entities.Oders
{
    public class AdminOrderWithItemsAndSpecification  : Specification<AdminOrder>
    {
          public AdminOrderWithItemsAndSpecification(int id) 
        : base(o=>o.id==id)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.delivery);
            AddProdInclude(o=>o.address);
        }

        public AdminOrderWithItemsAndSpecification(int id, string email) 
        : base(o=>o.id==id && o.Email==email)
        {
            AddProdInclude(o=>o.itemOrdered);
            AddProdInclude(o=>o.delivery);
            AddProdInclude(o=>o.address);
        }

         public AdminOrderWithItemsAndSpecification(OrderStatus orderStatus) 
        : base(o=>o.orderStatus==orderStatus)
        {
            AddProdInclude(o=>o.itemOrdered);
            // AddProdInclude(o=>o.confirmation);
            AddProdInclude(o=>o.address);
            AddOrderByDescending(o=>o.orderDate);
        }
    }
}
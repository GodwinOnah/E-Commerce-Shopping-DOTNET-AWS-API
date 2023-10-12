using core.Entities.Oders;
using core.Interfaces;

namespace infrastructure.Services
{
    public class AdminOrderService : IAdminOrder
    {


    
        private readonly IUnitOfWork _iUnitOfWork;
        public AdminOrderService(IUnitOfWork iUnitOfWork,
         IBasket basketRepo)
        {
            _iUnitOfWork = iUnitOfWork;
           
        }
        

        public async Task<IReadOnlyList<AdminOrder>> GetAdminOrderhsAsync(OrderStatus orederStatus)
        {
          var specification = new AdminOrderWithItemsAndSpecification(orederStatus);
            return await _iUnitOfWork.Repository<AdminOrder>()
            .ListAllAsync(specification);
            
        
        }

        public async Task<AdminOrder> GetAdminOrdersByIdAsync(int id)
        {
           var specification = new AdminOrderWithItemsAndSpecification(id);
            return await _iUnitOfWork.Repository<AdminOrder>()
            .GetProductsWithSpecification(specification);
        }

        public async Task DeletAdminOrder(int id)
        {
         _iUnitOfWork.deleteAdminOrder(id);

         await _iUnitOfWork.complete();
        }

        public async Task<bool> UpdateAdminOrdersByIdAsync(OrderConfirmDetails details)
        {
            
            var specification = new AdminOrderWithItemsAndSpecification(details.id,details.Email);
            var adminOrder = await  _iUnitOfWork.Repository<AdminOrder>()
            .GetProductsWithSpecification(specification);

            if(adminOrder != null){
                adminOrder.confirmation = "confirmed";
                _iUnitOfWork.Repository<AdminOrder>().Update(adminOrder);
              await  _iUnitOfWork.complete();

            }
            return true;

        }
    }
}
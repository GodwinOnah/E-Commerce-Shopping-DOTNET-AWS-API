using core.Controllers;
using core.Interfaces;

namespace infrastructure.Services
{
    public class ProductTypeService : IProductType
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public ProductTypeService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public async Task DeleteTypeAsync(int id)
        {
            await _iUnitOfWork.deleteProductType(id);

             await _iUnitOfWork.complete();
        }

        public async Task UploadTypeAsync(ProductType type)
        {
            var productType = new ProductType(){
                id = type.id,
                Name = type.Name
            };

             _iUnitOfWork.Repository<ProductType>().Add(productType);

              await _iUnitOfWork.complete();
        }

        
    }
}
        
   
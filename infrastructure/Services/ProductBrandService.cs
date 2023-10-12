using core.Controllers;
using core.Interfaces;

namespace infrastructure.Services
{
    public class ProductBrandService : IProductBrand
    {

        private readonly IUnitOfWork _iUnitOfWork;
        public ProductBrandService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public async Task DeleteBrandAsync(int id)
        {
             _iUnitOfWork.deleteProductBrand(id);

             await _iUnitOfWork.complete();
        }

        public async Task UploadBrandAsync(ProductBrand brand)
        {
            var productBrand = new ProductBrand(){
                id = brand.id,
                Name = brand.Name
            };
             _iUnitOfWork.Repository<ProductBrand>().Add(productBrand);
              await _iUnitOfWork.complete();
        }
    }
}
using AutoMapper;
using core.Controllers;
using core.Entities.DTOs;
using core.Interfaces;
using infrastructure.data;

namespace infrastructure.Services
{
    public class ProductServices : IProductDetails
    {
        
        
        private readonly IUnitOfWork _iUnitOfWork;
         private readonly IMapper _imapper;
          private readonly productContext _context;
        public ProductServices(
            IUnitOfWork iUnitOfWork,
            productContext context,
            IMapper imapper)
        {
            _iUnitOfWork = iUnitOfWork;
            _imapper = imapper;
            _context = context;
            
        }

        public async Task UploadProductAsync(ProductDetails productsDetails)
        {      
            var product = new Products() {  
                prodName = productsDetails.prodName,
                prodPicture = productsDetails.prodPicture,
                prodDescription = productsDetails.prodDescription,
                prodPrice = productsDetails.prodPrice,
                productBrandId =  productsDetails.productBrandId,
                productTypeId = productsDetails.productTypeId
            };
// Console.WriteLine("\n\n\n\n\n\n\n\n"+product.productBrandId+product.productTypeId+"\n\n\n\n\n\n\n\n");
            _iUnitOfWork.Repository<Products>().Add(product);

            await _iUnitOfWork.complete();
       
    }
     public async Task DeleteProductAsync(int id)
        {
            await  _iUnitOfWork.delete(id);

             await _iUnitOfWork.complete();

          
           
        }
}
}
using core.Entities.DTOs;

namespace core.Interfaces
{
    public interface IProductDetails
    {
        Task UploadProductAsync(ProductDetails productsDetails);
        Task DeleteProductAsync(int id);
    }
}
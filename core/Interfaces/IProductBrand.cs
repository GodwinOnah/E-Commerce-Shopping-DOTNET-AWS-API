using core.Controllers;

namespace core.Interfaces
{
    public interface IProductBrand
    {
        Task UploadBrandAsync(ProductBrand brand);
        Task DeleteBrandAsync(int id);
    }
}
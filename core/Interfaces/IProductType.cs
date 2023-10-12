using core.Controllers;

namespace core.Interfaces
{
    public interface IProductType
    {
         Task UploadTypeAsync(ProductType brand);
        Task DeleteTypeAsync(int id);
    }
}
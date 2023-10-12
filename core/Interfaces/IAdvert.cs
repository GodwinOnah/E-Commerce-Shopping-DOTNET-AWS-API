using core.Entities.Adverts;

namespace core.Interfaces
{
    public interface IAdvert
    {
        Task UploadProductsUrlToDb(Adverts advert);
        Task<Adverts> GetAdvertsById(int id);
        Task<IReadOnlyList<Adverts>> GetAdverts();
        Task<bool> DeleteAverts(int id);
    }
}
using core.Entities.Adverts;
using core.Interfaces;
using core.Specifications;

namespace infrastructure.Services
{
    public class AdvertService : IAdvert
    {

         private readonly IUnitOfWork _iUnitOfWork;
        public AdvertService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
           
        }
        public async Task<IReadOnlyList<Adverts>> GetAdverts()
        {
           
          return await _iUnitOfWork.Repository<Adverts>().ListAllAsync();
    
        }

         public async Task<Adverts> GetAdvertsById(int id)
        {
             var specification = new AdvertItemsAndSpecification(id);
          return await _iUnitOfWork.Repository<Adverts>().GetProductsWithSpecification(specification);
    
        }  

        public async Task UploadProductsUrlToDb(Adverts advert)
        {
           _iUnitOfWork.Repository<Adverts>().Add(advert);
           await _iUnitOfWork.complete();
        }

         public async Task<bool> DeleteAverts(int id)
        {
          _iUnitOfWork.deleteAdverts(id);
           await _iUnitOfWork.complete();
          return true;
            
        }
    }
}
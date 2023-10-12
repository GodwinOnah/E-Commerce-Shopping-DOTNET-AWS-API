using core.Entities.Adverts;
using infrastructure.data;

namespace core.Specifications
{
    public class AdvertItemsAndSpecification : Specification<Adverts>
    {
         public AdvertItemsAndSpecification(int id) 
        : base(o=>o.id==id)
        {
            AddProdInclude(o=>o.advert);
            AddProdInclude(o=>o.time);
            
        }
    }
}
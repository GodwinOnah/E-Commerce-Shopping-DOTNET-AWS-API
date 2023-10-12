using core.Entities.Adverts;
using infrastructure.data;


namespace core.Specifications
{
    public class AdvertSpecicification : Specification<Adverts>
    {

        public AdvertSpecicification(int id) 
        : base(o=>o.id==id)
        {
            AddProdInclude(o=>o.advert);
            AddProdInclude(o=>o.id);
             AddProdInclude(o=>o.time);
            
        }
        
    }
}
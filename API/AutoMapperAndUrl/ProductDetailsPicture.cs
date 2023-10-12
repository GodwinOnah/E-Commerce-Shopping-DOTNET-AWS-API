using AutoMapper;
using core.Controllers;
using core.Entities.DTOs;

namespace API.AutoMapperAndUrl
{
    public class ProductDetailsPicture :IValueResolver<ProductDetails,Products, string>
    {
       
        private readonly IConfiguration _configuration;
        public ProductDetailsPicture(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(ProductDetails source, Products destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.prodPicture))
            {
                return _configuration["ApiUrl"]+source.prodPicture;
            }

            return null;
        }
    }
    }

using API.DTOs;
using AutoMapper;
using core.Controllers;

namespace API.AutoMapperAndUrl
{
    public class ProductPictureUrl : IValueResolver<Products, ProductsShapedObject, string>
    {
        private readonly IConfiguration _configuration;
        public ProductPictureUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Products source, ProductsShapedObject destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.prodPicture))
            {
                return _configuration["ApiUrl"]+source.prodPicture;
            }

            return null;
        }
    }
}
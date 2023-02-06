using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.AutoMapperAndUrl;
using API.DTOs;
using AutoMapper;
using core;
using core.Controllers;
using core.Entities;
using core.Entities.Identity;

namespace API.AutoMapper
{
    public class MappingProductProfile : Profile//this code removes the null property of product brand and types
    {
        public MappingProductProfile()
        {
            CreateMap<Products, ProductsShapedObject>()
            .ForMember(x=>x.productBrand,y=>y.MapFrom(z=>z.productBrand.Name))
            .ForMember(x=>x.productType,y=>y.MapFrom(z=>z.productType.Name))
            .ForMember(x=>x.prodPicture,y=>y.MapFrom<ProductPictureUrl>());

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<BasketDTO, Basket>();
            CreateMap<BasketItemsDTO, BasketItems>();
        }
    }
}
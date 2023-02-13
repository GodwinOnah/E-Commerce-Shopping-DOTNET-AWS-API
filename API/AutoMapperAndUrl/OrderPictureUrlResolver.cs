using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using core.Entities.Oders;

namespace API.AutoMapperAndUrl
{
    public class OrderPictureUrlResolver: IValueResolver<ItemOrdered, ItemOrderedDTO, string>
    {
        private readonly IConfiguration _configuration;
        public OrderPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(ItemOrdered source, ItemOrderedDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.itemOrdered.prodPicture))
            {

                return _configuration["ApiUrl"]+source.itemOrdered.prodPicture;
            }

            return null;
        }
    }
        
    }

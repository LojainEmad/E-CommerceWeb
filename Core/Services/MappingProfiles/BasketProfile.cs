using AutoMapper;
using Domain.Models.Basket;
using Shared.Dto_s.BasketBto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class BasketProfile:Profile
    {

        public BasketProfile()
        {
            CreateMap<CustomerBasket ,BasketDto>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}

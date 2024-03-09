using AutoMapper;
using BookControl.Dto.Request;
using BookControl.Dto.Response;
using BookControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Orders, OrderResponseDto>();
            CreateMap<OrderRequestDto, Orders>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            CreateMap<OrderDetailRequestDto, OrderDetail>();
            CreateMap<OrderUpdateRequestDto, Orders>();

        }
    }
}

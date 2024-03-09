using AutoMapper;
using BookControl.Dto.Response;
using BookControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<CustomerRequestDto, Customer>();
        }
    }
}

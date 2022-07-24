using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using asp.net_mvc_webapp.Models;
using asp.net_mvc_webapp.Dtos;

namespace asp.net_mvc_webapp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}
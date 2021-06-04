using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models;
using WebAPI1.Models.Dtos;

namespace WebAPI1.Mapper
{
    public class WebMappings: Profile
    {
        public WebMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}

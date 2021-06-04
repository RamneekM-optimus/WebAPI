using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models.Dtos;
using WebAPI1.Repository.IRepository;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository npRepo, IMapper _mp)
        {
            _nationalParkRepository = npRepo;
            _mapper = _mp;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var ojectList = _nationalParkRepository.GetNationalParks();
            var objDto = new List<NationalParkDto>();
            foreach(var obj in ojectList)
            {
                objDto.Add(_mapper.Map<NationalParkDto>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet("{nationalParkId:int}")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var oject = _nationalParkRepository.GetNationalPark(nationalParkId);
            if(oject == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<NationalParkDto>(oject);
            return Ok(objDto);
        }
    }
}

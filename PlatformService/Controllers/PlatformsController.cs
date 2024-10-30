

using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers  // Updated to "Controllers"
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatfromRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatfromRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            Console.WriteLine("Getting platforms");

            var platforms = _platformRepo.GetAllPlatforms();  // Ensure this method exists
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }


        [HttpGet("{Id}",Name ="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int Id)
        {
            var platform = _platformRepo.GetPlatformById(Id);

            if(platform != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platform));
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto dto)
        {
            
            var platformEntitiy = _mapper.Map<Platfrom>(dto);

            _platformRepo.CreatePlatfrom(platformEntitiy);

            _platformRepo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformEntitiy);

            //return Ok(platformReadDto);
            
            return CreatedAtAction(nameof(GetPlatformById),new {platformReadDto.Id} ,platformReadDto);
        }
    }
}

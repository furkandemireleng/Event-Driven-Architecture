using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace  PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source --> Target
            CreateMap<Platfrom,PlatformReadDto>();

            CreateMap<PlatformCreateDto,Platfrom>();
        }
    }
}
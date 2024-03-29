using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        /*
            Cause our platform class and our platformReadDto has properties
            That are named exactly the same, we dont need tell auto mapper anything else. 
        */
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<Platform, PlatformPublishedDto>();
            CreateMap<PlatformReadDto, PlatformPublishedDto>();
            CreateMap<Platform, GrpcPlatformModel>()
                .ForMember(dest => dest.PlatformId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
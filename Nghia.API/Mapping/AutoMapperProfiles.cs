using AutoMapper;
using Nghia.API.Models.Domain;
using Nghia.API.Models.DTO;

namespace Nghia.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<CreateAndUpdateRegionDTO, Region>().ReverseMap();
            CreateMap<CreateAndUpdateWalkDTO, Walk>().ReverseMap();
            CreateMap<Walk,  WalkDTO>().ReverseMap();

        }
    }
}

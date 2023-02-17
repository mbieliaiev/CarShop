using AutoMapper;
using CarShop.Data;
using CarShop.Dto;

namespace CarShop.Service.Implementation.MappingProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile() {
            CreateMap<CarEntity, CarDto>()
                .ForMember(c => c.Photo, c => c.Ignore())
                .ForMember(c => c.PhotoBytes, c => c.MapFrom(p => p.Photo));

            CreateMap<CarDto, CarEntity>()
                .ForMember(c => c.Photo, c => c.Ignore());
        }
    }
}

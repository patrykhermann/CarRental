using AutoMapper;

namespace CarRental.API.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Models.CarForCreationDto, Entities.Car>();
            CreateMap<Entities.Car, Models.CarForCreationDto>();
            CreateMap<Models.CarForUpdateDto, Entities.Car>();
            CreateMap<Entities.Car, Models.CarForUpdateDto>();
        }
    }
}

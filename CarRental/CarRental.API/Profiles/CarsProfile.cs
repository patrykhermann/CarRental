using AutoMapper;

namespace CarRental.API.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Models.CarForCreationDto, Entities.Car>();
        }
    }
}

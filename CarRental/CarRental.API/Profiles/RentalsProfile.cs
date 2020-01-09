using AutoMapper;

namespace CarRental.API.Profiles
{
    public class RentalsProfile : Profile
    {
        public RentalsProfile()
        {
            CreateMap<Entities.Rental, Models.RentalDto>();
            CreateMap<Models.RentalForCreationDto, Entities.Rental>();
        }
    }
}

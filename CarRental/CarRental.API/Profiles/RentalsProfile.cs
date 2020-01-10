using AutoMapper;

namespace CarRental.API.Profiles
{
    public class RentalsProfile : Profile
    {
        public RentalsProfile()
        {
            CreateMap<Entities.Rental, Models.RentalDto>()
                .ForMember(
                dest => dest.Car,
                opt => opt.MapFrom(src => $"{src.Car.Brand} {src.Car.Model}"))
                .ForMember(
                dest => dest.Client,
                opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"));
            CreateMap<Models.RentalForCreationDto, Entities.Rental>();
            CreateMap<Models.RentalForUpdateDto, Entities.Rental>();
            CreateMap<Entities.Rental, Models.RentalForUpdateDto>();
        }
    }
}

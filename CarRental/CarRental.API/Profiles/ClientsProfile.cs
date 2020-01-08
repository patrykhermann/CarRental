using AutoMapper;
using CarRental.API.Helpers;

namespace CarRental.API.Profiles
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            CreateMap<Entities.Client, Models.ClientDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}

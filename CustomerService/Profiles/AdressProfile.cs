using AutoMapper;
using CustomerService.Dtos;
using CustomerService.Models;

namespace CustomerService.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<Adress, AdressDto>();
            CreateMap<AdressDto, Adress>();

        }
    }
}

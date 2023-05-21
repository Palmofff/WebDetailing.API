using AutoMapper;

namespace WebDetailing.API.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Requests.CarRequest, Models.Car>();
        CreateMap<Models.Car, Models.CarDto>();
    }
}
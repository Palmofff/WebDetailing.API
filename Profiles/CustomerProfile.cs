using AutoMapper;

namespace WebDetailing.API.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Models.Customer, Models.CustomerDto>();
        CreateMap<Requests.CustomerRequest, Models.Customer>();
        CreateMap<Models.Customer, Models.CustomerDto>();
        CreateMap<Models.Customer, Models.CustomerWithoutCarsDto>();
    }
}
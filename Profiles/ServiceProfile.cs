using AutoMapper;

namespace WebDetailing.API.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Requests.ServiceRequest, Models.Service>();
        CreateMap<Models.Service, Models.ServiceDto>();
    }
}
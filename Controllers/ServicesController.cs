using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebDetailing.API.Models;
using WebDetailing.API.Requests;
using WebDetailing.API.Utilities;

namespace WebDetailing.API.Controllers;
[ApiController]
[Route("service")]
public class ServicesController : ControllerBase
{
    private readonly IWebDetailingRepository _webDetailingRepository;
    private readonly IMapper _mapper;

    public ServicesController(IWebDetailingRepository webDetailingRepository, IMapper mapper)
    {
        _webDetailingRepository = webDetailingRepository ?? 
                                  throw new ArgumentNullException(nameof(webDetailingRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> AddService([FromBody]ServiceRequest serviceRequest)
    {
        var service = _mapper.Map<Service>(serviceRequest);
        await _webDetailingRepository.AddServiceAsync(service, 
            serviceRequest.PlateNumber, serviceRequest.CustomerId);
        await _webDetailingRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(AddService), new { Id = service.Id }, _mapper.Map<ServiceDto>(service));
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var services = await _webDetailingRepository.GetServicesAsync();
        return Ok(_mapper.Map<IEnumerable<ServiceDto>>(services));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(int id)
    {
        var service = await _webDetailingRepository.GetServiceAsync(id);
        return Ok(_mapper.Map<ServiceDto>(service));
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetServicesForCustomer(int customerId)
    {
        var services = await _webDetailingRepository
            .GetServiceForCustomerAsync(customerId);
        return Ok(_mapper.Map<IEnumerable<ServiceDto>>(services));
    }

    [HttpGet("car/{plateNumber}")]
    public async Task<IActionResult> GetServiceForCar(string plateNumber)
    {
        var services = await _webDetailingRepository
            .GetServiceForCarAsync(plateNumber);
        return Ok(_mapper.Map<IEnumerable<ServiceDto>>(services));
    }
}
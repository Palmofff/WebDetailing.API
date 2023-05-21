using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebDetailing.API.DbContexts;
using WebDetailing.API.Models;
using WebDetailing.API.Requests;
using WebDetailing.API.Utilities;

namespace WebDetailing.API.Controllers;
[ApiController]
[Route("car")]
public class CarsController : ControllerBase
{
    private readonly IWebDetailingRepository _webDetailingRepository;
    private readonly IMapper _mapper;

    public CarsController(IWebDetailingRepository webDetailingRepository, IMapper mapper)
    {
        _webDetailingRepository = webDetailingRepository ?? throw
            new ArgumentNullException(nameof(webDetailingRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("customer/{customerId}")]
    public async Task<CreatedAtActionResult> CreateCar(int customerId,[FromBody] CarRequest carRequest)
    {

        var car = _mapper.Map<Car>(carRequest);
        await _webDetailingRepository.AddCarForCustomerAsync(customerId, car);
        await _webDetailingRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(CreateCar),new
        {
            CustomerId = customerId,
            PlateNumber = car.PlateNumber
        }, carRequest);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetCars(int customerId)
    {
        var cars = await _webDetailingRepository.GetCarsAsync(customerId);
        return Ok(_mapper.Map<IEnumerable<CarDto>>(cars));
    }

    [HttpGet("{plateNumber}")]
    public async Task<IActionResult> GetCar(string plateNumber)
    {
        var car = await _webDetailingRepository.GetCarAsync(plateNumber);
        return Ok(_mapper.Map<CarDto>(car));
    }
}
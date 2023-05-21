using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDetailing.API.DbContexts;
using WebDetailing.API.Models;
using WebDetailing.API.Requests;
using WebDetailing.API.Utilities;

namespace WebDetailing.API.Controllers;
[ApiController]
[Route("customer")]
public class CustomersController : ControllerBase
{
   
    private readonly IMapper _mapper;
    private readonly IWebDetailingRepository _webDetailingRepository;

    public CustomersController(DetailingContext context, IMapper mapper, IWebDetailingRepository webDetailingRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _webDetailingRepository = webDetailingRepository ?? throw new ArgumentNullException(nameof(webDetailingRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        var collection = await  _webDetailingRepository.GetCustomersAsync();
        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(collection));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _webDetailingRepository.GetCustomerAsync(id);
        return Ok(_mapper.Map<CustomerDto>(customer));
    }



    [HttpPost]
    public async Task<CreatedAtActionResult> CreateCustomer([FromBody] CustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        await _webDetailingRepository.AddCustomerAsync(customer);
        await _webDetailingRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(CreateCustomer), new
        { CustomerId = customer.Id}, _mapper.Map<CustomerWithoutCarsDto>(customer));
    }
}
    
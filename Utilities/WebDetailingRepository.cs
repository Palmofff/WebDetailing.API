using Microsoft.EntityFrameworkCore;
using WebDetailing.API.DbContexts;
using WebDetailing.API.Models;
using WebDetailing.API.Requests;

namespace WebDetailing.API.Utilities;

public class WebDetailingRepository : IWebDetailingRepository
{
    private readonly DetailingContext _context;

    public WebDetailingRepository(DetailingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task AddServiceAsync(Service service, string plateNumber, int customerId)
    {
        var car = await GetCarAsync(plateNumber);
        var customer = await GetCustomerAsync(customerId);
        service.Car = car;
        service.Customer = customer;
        _context.Services.Add(service);
    }

    public async Task<IEnumerable<Service>> GetServicesAsync()
    {
        return await _context.Services.
            Include(s => s.Customer).
            Include(s =>s.Car).ToListAsync();
    }

    public async Task<Service?> GetServiceAsync(int id)
    {
        return await _context.Services.Where(s => s.Id == id)
            .Include(s => s.Customer)
            .Include(s => s.Car)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Service>> GetServiceForCustomerAsync(int customerId)
    {
        var customer = await GetCustomerAsync(customerId);
        return await _context.Services.Where(s => s.Customer == customer)
            .Include(s => s.Customer)
            .Include(s => s.Car)
            .ToListAsync();
    }

    public async Task<IEnumerable<Service>> GetServiceForCarAsync(string plateNumber)
    {
        var car = await GetCarAsync(plateNumber);
        return await _context.Services.Where(s => s.Car == car)
            .Include(s => s.Customer)
            .Include(s => s.Car)
            .ToListAsync();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _context.Customers
            .Include(c => c.Cars)
            .OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Customer?> GetCustomerAsync(int customerId)
    {
        return await _context.Customers
            .Include(c => c.Cars)
            .Where(c => c.Id == customerId).FirstOrDefaultAsync();
    }

    public async Task AddCarForCustomerAsync(int customerId, Car car)
    {
        var customer  = await GetCustomerAsync(customerId);
        
        customer?.Cars.Add(car);
    }

    public async Task<Car> GetCarAsync(string plateNumber)
    {
        return await _context.Cars.Where(c => c.PlateNumber == plateNumber)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsAsync(int id)
    {
        return await _context.Cars.Where(c => c.CustomerId == id).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
using WebDetailing.API.Models;
using WebDetailing.API.Profiles;
using WebDetailing.API.Requests;

namespace WebDetailing.API.Utilities;

public interface IWebDetailingRepository
{
    Task AddServiceAsync(Service service, 
        string plateNumber, int customerId);
    Task<IEnumerable<Service>> GetServicesAsync();
    Task<Service?> GetServiceAsync(int id);
    Task<IEnumerable<Service>> GetServiceForCustomerAsync(int customerId);
    Task<IEnumerable<Service>> GetServiceForCarAsync(string plateNumber);
    Task AddCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerAsync(int customerId);
    Task AddCarForCustomerAsync(int customerId, Car car);
    Task<Car> GetCarAsync(string plateNumber);
    Task<IEnumerable<Car>> GetCarsAsync(int id);
    Task<bool> SaveChangesAsync();
}
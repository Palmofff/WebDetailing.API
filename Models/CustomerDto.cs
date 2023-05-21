namespace WebDetailing.API.Models;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public int NumberOfCars
    {
        get
        {
            return Cars.Count;
        }
    }
    public ICollection<CarDto> Cars { get; set; }
        = new List<CarDto>();
}
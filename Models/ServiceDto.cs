namespace WebDetailing.API.Models;

public class ServiceDto
{
    public int Id{ get; set; }
    public string? ServicesProvided { get; set; }
    public int Price { get; set; }
    public CustomerWithoutCarsDto Customer { get; set; }
    public CarDto Car { get; set; }
}
namespace WebDetailing.API.Requests;

public class ServiceRequest
{
    public string? ServicesProvided { get; set; }
    public int Price { get; set; }
    public int CustomerId { get; set; }
    public string PlateNumber { get; set; }
}
﻿namespace WebDetailing.API.Models;

public class CustomerWithoutCarsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
}
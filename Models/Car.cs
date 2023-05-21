using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDetailing.API.Models;

public class Car
{
    [Key]
    [MaxLength(50)]
    public string? PlateNumber { get; set; } 
    [Required]
    [MaxLength(100)]
    public string? Model { get; set; }
    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
}
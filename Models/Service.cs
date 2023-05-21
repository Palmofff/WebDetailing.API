using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDetailing.API.Models;

public class Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    [MaxLength(50)]
    public string? ServicesProvided { get; set; }
    [Required]
    public int Price { get; set; }
    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey("PlateNumber")]
    public Car Car { get; set; }
    public string PlateNumber { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDetailing.API.Models;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
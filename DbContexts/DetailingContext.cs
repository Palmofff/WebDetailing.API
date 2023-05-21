using Microsoft.EntityFrameworkCore;
using WebDetailing.API.Models;

namespace WebDetailing.API.DbContexts;

public class DetailingContext : DbContext
{
    public DetailingContext(DbContextOptions<DetailingContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Car?> Cars { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
}
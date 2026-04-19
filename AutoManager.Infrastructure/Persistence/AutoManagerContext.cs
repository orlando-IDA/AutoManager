using Microsoft.EntityFrameworkCore;
using AutoManager.Domain.Entities;
using AutoManager.Infrastructure.Persistence.Configurations;

namespace AutoManager.Infrastructure.Persistence;

public class AutoManagerContext(DbContextOptions<AutoManagerContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutoManagerContext).Assembly);
    }
}
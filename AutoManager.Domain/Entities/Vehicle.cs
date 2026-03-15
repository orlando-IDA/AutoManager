using AutoManager.Domain.Common;

namespace AutoManager.Domain.Entities;

public class Vehicle : BaseEntity
{
    public string LicensePlate { get; private set; }
    public string Manufacturer { get; private set; }
    public string Model { get; private set; }
    
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } 
    
    public List<ServiceOrder> ServiceOrders { get; private set; } = new();

    public Vehicle(string licensePlate, string manufacturer, string model, int customerId)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
            throw new Exception("The license plate is required.");
            
        if (string.IsNullOrWhiteSpace(manufacturer))
            throw new Exception("The manufacturer is required.");

        LicensePlate = licensePlate;
        Manufacturer = manufacturer;
        Model = model;
        CustomerId = customerId;
    }
}
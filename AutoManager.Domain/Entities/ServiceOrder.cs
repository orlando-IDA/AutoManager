using AutoManager.Domain.Common;
using AutoManager.Domain.Enums;

namespace AutoManager.Domain.Entities;

public class ServiceOrder : BaseEntity
{
    public DateTime EntryDate { get; private set; }
    public ServiceOrderStatusEnum Status { get; private set; }

    public int VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; } 
    
    public List<OrderItem> Items { get; private set; } = new();
    
    // Can be null until the service is done.
    public Payment? Payment { get; private set; } 

    public ServiceOrder(DateTime entryDate, ServiceOrderStatusEnum status, int vehicleId)
    {
        if (entryDate > DateTime.UtcNow)
            throw new Exception("The entry date cannot be in the future.");

        EntryDate = entryDate;
        Status = status;
        VehicleId = vehicleId;
    }
    
    public void UpdateStatus(ServiceOrderStatusEnum newStatus)
    {
        Status = newStatus;
    }
}
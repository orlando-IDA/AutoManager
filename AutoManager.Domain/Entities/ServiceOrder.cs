using AutoManager.Domain.Common;
using AutoManager.Domain.Enums;

namespace AutoManager.Domain.Entities;

public class ServiceOrder : BaseEntity
{
    public DateTime EntryDate { get; private set; }
    public ServiceOrderStatusEnum Status { get; private set; }

    public Guid VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; } = null!;
    
    public List<OrderItem> Items { get; private set; } = new();
    
    public Payment? Payment { get; private set; } 

    public ServiceOrder(DateTime entryDate, Guid vehicleId)
    {
        if (entryDate == default)
            throw new Exception("Entry Date is invalid");

        EntryDate = entryDate;
        VehicleId = vehicleId;
        Status = ServiceOrderStatusEnum.Pendente;
    }
    
    public void UpdateStatus(ServiceOrderStatusEnum newStatus)
    {
        Status = newStatus;
    }
}
using AutoManager.Domain.Entities;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.DTOs;

public record ServiceOrderResponse(Guid id, DateTime entryDate, ServiceOrderStatusEnum status, Guid vehicleId)
{
    public static ServiceOrderResponse FromDomain(ServiceOrder order) => 
        new(order.Id, order.EntryDate, order.Status, order.VehicleId);
}
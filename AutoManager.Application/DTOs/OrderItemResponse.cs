using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record OrderItemResponse(Guid id, string description, decimal price, Guid serviceOrderId)
{
    public static OrderItemResponse FromDomain(OrderItem item) => 
        new(item.Id, item.Description, item.Price, item.ServiceOrderId);
}
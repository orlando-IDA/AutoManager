using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager.Infrastructure;

public sealed class OrderItemRepository(AutoManagerContext context) : IOrderItemRepository
{
    public IReadOnlyList<OrderItemResponse> GetByServiceOrderId(Guid serviceOrderId)
    {
        return context.OrderItems
            .Where(oi => oi.ServiceOrderId == serviceOrderId)
            .Select(OrderItemResponse.FromDomain)
            .ToList();
    }

    public OrderItemResponse Create(OrderItemRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        var item = request.ToDomain();

        context.OrderItems.Add(item);
        context.SaveChanges();

        return OrderItemResponse.FromDomain(item);
    }

    public bool Delete(Guid id)
    {
        var item = context.OrderItems.FirstOrDefault(oi => oi.Id == id);
        if (item is null) return false;

        context.OrderItems.Remove(item);
        context.SaveChanges();

        return true;
    }
}
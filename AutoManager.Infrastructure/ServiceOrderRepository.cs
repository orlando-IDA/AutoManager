using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Domain.Enums;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager.Infrastructure;

public sealed class ServiceOrderRepository(AutoManagerContext context) : IServiceOrderRepository
{
    public IReadOnlyList<ServiceOrderResponse> GetAll()
    {
        return context.ServiceOrders
            .OrderByDescending(so => so.EntryDate)
            .Select(ServiceOrderResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<ServiceOrderResponse> GetByVehicleId(Guid vehicleId)
    {
        return context.ServiceOrders
            .Where(so => so.VehicleId == vehicleId)
            .OrderByDescending(so => so.EntryDate)
            .Select(ServiceOrderResponse.FromDomain)
            .ToList();
    }

    public ServiceOrderResponse? GetById(Guid id)
    {
        var order = context.ServiceOrders.FirstOrDefault(so => so.Id == id);
        return order is null ? null : ServiceOrderResponse.FromDomain(order);
    }

    public ServiceOrderResponse Create(ServiceOrderRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        var order = request.ToDomain();

        context.ServiceOrders.Add(order);
        context.SaveChanges();

        return ServiceOrderResponse.FromDomain(order);
    }

    public bool UpdateStatus(Guid id, ServiceOrderStatusEnum status)
    {
        var order = context.ServiceOrders.FirstOrDefault(so => so.Id == id);
        if (order is null) return false;

        order.UpdateStatus(status);
        context.SaveChanges();

        return true;
    }

    public bool Delete(Guid id)
    {
        var order = context.ServiceOrders.FirstOrDefault(so => so.Id == id);
        if (order is null) return false;

        context.ServiceOrders.Remove(order);
        context.SaveChanges();

        return true;
    }
}
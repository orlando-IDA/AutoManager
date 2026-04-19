using AutoManager.Application.DTOs;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.Services;

public interface IServiceOrderRepository
{
    IReadOnlyList<ServiceOrderResponse> GetAll();
    IReadOnlyList<ServiceOrderResponse> GetByVehicleId(Guid vehicleId);
    ServiceOrderResponse? GetById(Guid id);
    ServiceOrderResponse Create(ServiceOrderRequest request);
    bool UpdateStatus(Guid id, ServiceOrderStatusEnum status);
    bool Delete(Guid id);
}
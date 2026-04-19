using AutoManager.Application.DTOs;

namespace AutoManager.Application.Services;

public interface IOrderItemRepository
{
    IReadOnlyList<OrderItemResponse> GetByServiceOrderId(Guid serviceOrderId);
    OrderItemResponse Create(OrderItemRequest request);
    bool Delete(Guid id);
}
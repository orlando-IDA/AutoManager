using AutoManager.Application.DTOs;

namespace AutoManager.Application.Services;

public interface IPaymentRepository
{
    PaymentResponse? GetByServiceOrderId(Guid serviceOrderId);
    PaymentResponse Create(PaymentRequest request);
}